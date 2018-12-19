title: Creating an image set with various shapes 
lead: Generating imageset with different shapes like circle or rectangle for CNN learning
Published: 2018-12-15
Tags: [matlab, imageset, shapes, random, transfer learning]
prerequisites: [Matlab]
Authors: tesar-tech
---

Script creates folder `imgs_shapes` and subfolders with name of the shape. Shapes with different color, size and position are generated in those subploders. This image database will be used to train CNN for shapes classification.

``` matlab
numImgInClass = 10;%number of imgs in every class
imgSize= 227; %respect alexnet input size
Canvas = zeros(imgSize);

mkdir('imgs_shapes');% create folders for shapes
mkdir('imgs_shapes/circle');
mkdir('imgs_shapes/rectangle');
mkdir('imgs_shapes/triangle');

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
        alpha=acos((sides(2).^2+sides(3).^2-sides(1).^2)/(2*sides(2) * sides(3))); %Law of Cosines -> alpha angle in radians
        beta=rad2deg(asin((sides(2)/sides(1))*sin(alpha))); %Law of Sines -> beta angle in degrees
        gamma=180-beta-(rad2deg(alpha)); % gamma angle
    end
    
    point_vector=[point(1,:),point(2,:),point(3,:)];
    colorRnd = rand([1 3]);
    RGBtriangle= insertShape(Canvas,'FilledPolygon',point_vector,'color',colorRnd);
    
    imwrite(RGBtriangle,fullfile('imgs_shapes/triangle',['triangle_' num2str(ii,'%03i') '.jpg']  ))
    
    disp(['creating img db: ' num2str(ii/numImgInClass*100,'%.2f') ' %'])
end

```