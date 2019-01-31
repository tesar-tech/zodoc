title: Creating an image set with various shapes 
lead: Generating imageset with different shapes like circle or rectangle for CNN learning
Published: 2018-12-15
Tags: [matlab, imageset, shapes, random, transfer learning]
prerequisites: [Matlab]
Authors: [tesar-tech, strakka1,magias]
---

Script creates folder `imgs_shapes` and subfolders with name of the shape. Shapes with different color, size and position are generated in those subploders. This image database will be used to train CNN for shapes classification.

``` matlab
numImgInClass = 10;%number of imgs in every class
imgSize= 227; %respect alexnet input size
Canvas = zeros(imgSize);

stepSize = 360 / 5; %angle for pentagons
angles1 = 0 : stepSize : 360; %angle for first pentagon
angles2 = stepSize/2 : stepSize : 360 + stepSize/2; %angle for second pentagon

mkdir('imgs_shapes');% create folders for shapes
mkdir('imgs_shapes/circle');
mkdir('imgs_shapes/rectangle');
mkdir('imgs_shapes/triangle');
mkdir('imgs_shapes/star');

for ii = 1:numImgInClass
    %% create "random" circle
    
    colorRnd = rand([1 3]);
    radiusRnd = randi([10 80],1);
    
    posRnd = randi([radiusRnd imgSize-radiusRnd],[1 2]);
    RGBcircle = insertShape(Canvas,'FilledCircle',[posRnd radiusRnd],'color',colorRnd);
    
    imwrite(RGBcircle,fullfile('imgs_shapes/circle',['circle_' num2str(ii,'%03i') '.jpg']  ))
    
    %% create "random" rectangle
    colorRnd = rand([1 3]);
    heightHalfRnd = randi([10 80],1);
    widthHalfRnd = randi([10 80],1);
    
    posRnd = randi([1 imgSize-max(heightHalfRnd,widthHalfRnd)*2],[1 2]);
    RGBsquare = insertShape(Canvas,'FilledRectangle',[posRnd heightHalfRnd*2 widthHalfRnd*2],'color',colorRnd);
    
    imwrite(RGBsquare,fullfile('imgs_shapes/rectangle',['square_' num2str(ii,'%03i') '.jpg']  ))
    
    %% create "random" triangle
    %coordinates and angles must meet these conditions:
    %angle size >15 and every side >66(because of too small or narrow triangles), minimal two "x" and "y" coordinates must be different  
    
    alpha=0; beta=0; gamma=0; sides=[1,1,1]; point=[0 0; 1 1];
    while( rad2deg(alpha)<15 || beta<15 || gamma<15 || sum(sides(1,:)<66)>0  || numel(unique([point(1,1),point(2,1)]))==1 || numel(unique([point(1,2),point(2,2)]))==1 )
        point=randi([40 190],[3 2]); 
        sides=sort(pdist(point,'euclidean')); %Euclidean distance between 2 points = side length
        alpha=acos((sides(2).^2+sides(3).^2-sides(1).^2)/(2*sides(2) * sides(3)));  %Law of Cosines -> alpha angle in radians
        beta=rad2deg(asin((sides(2)/sides(1))*sin(alpha))); %Law of Sines -> beta angle in degrees
        gamma=180-beta-(rad2deg(alpha)); % gamma angle
    end
    
    point_vector=[point(1,:),point(2,:),point(3,:)];
    colorRnd = rand([1 3]);
    RGBtriangle= insertShape(Canvas,'FilledPolygon',point_vector,'color',colorRnd);
    
    imwrite(RGBtriangle,fullfile('imgs_shapes/triangle',['triangle_' num2str(ii,'%03i') '.jpg']  ))

    %% Create stars 
    %Random size of both pentagons
    r1 = randi([10 30],1);
    r2 = randi([40 80],1);

    %Generate coordinates for both pentagons
    x1 = r1 * cosd(angles1);
    y1 = r1 * sind(angles1);
    x2 = r2 * cosd(angles2);
    y2 = r2 * sind(angles2);

    %Redraw coordinates of pivotal pentagons into a star shape polygon
    x3 = reshape([x1;x2], 1, []);
    y3 = reshape([y1;y2], 1, []);

    %Move coordinates in the middle
    x3 = x3+imgSize/2;
    y3 = y3+imgSize/2;

    % Random shift
    x3 = x3+randi([-round(min(x3)) (imgSize - round(max(x3)))],1);
    y3 = y3+randi([-round(min(y3)) (imgSize - round(max(y3)))],1);

    % Redners mask of the 227x227 binary image from polygon coordinates into the star.
    maskImage = poly2mask(x3, y3, imgSize, imgSize);

    %Random rotation angle
    angleRand=randi([0 360],1);

    %Image rotation
    rotateImg = imrotate(maskImage,angleRand,'crop');

    %single channel whitestar
    whiteImage = 255 * uint8(rotateImg);

    %Radnom RGB channel generator
    RRand=randi([0 255],1);
    GRand=randi([0 255],1);
    BRand=randi([0 255],1);

    %Creates RGB image of the star with random color
    RGB = cat(3, whiteImage-RRand, whiteImage-GRand, whiteImage-BRand);
    imwrite(RGB,fullfile('imgs_shapes/star',['star_' num2str(ii,'%03i') '.jpg']  ))

    disp(['creating img db: ' num2str(ii/numImgInClass*100,'%.2f') ' %'])
end
```