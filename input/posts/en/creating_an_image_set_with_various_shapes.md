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
    %lenght of sides and angles must meet these conditions:
    %angle size limit(because of narrow flat triangle), every side >20(because of too small triangles), triangle inequality theorem, length of every side ~=0
    length_c = 0; length_a = 0; length_b = 0;angle_1=0; angle_2=0;
    
    while((angle_1<40 && angle_2<40) || angle_1<15 ||angle_2<15 ||(length_a<20 || length_b<20 || length_c<20) || (length_a+length_b<length_c || length_a+length_c<length_b || length_c+length_b<length_a) || (length_a==0 || length_b==0 || length_c==0))
        for n=1:3
            for j=1:2
                pointRnd(n,j)=randi([40 190]); %coordinates of vertices
            end
        end
        a=[pointRnd(2,1),pointRnd(2,2);pointRnd(3,1),pointRnd(3,2)]; %side "a" = starting point(vertex "b" ) and ending point(vertex "c")
        b=[pointRnd(1,1),pointRnd(1,2);pointRnd(3,1),pointRnd(3,2)];
        c=[pointRnd(1,1),pointRnd(1,2);pointRnd(2,1),pointRnd(2,2)];
        %Euclidean distance between two points = length of one side
        length_c = pdist(c,'euclidean'); 
        length_b = pdist(b,'euclidean');
        length_a = pdist(a,'euclidean');
        %angle size
        if length_c>length_a && length_c>length_b  
            angle_1= (sin(length_b/length_c))*180/pi; 
            angle_2= (sin(length_a/length_c))*180/pi;
        elseif  length_b>length_a && length_b>length_c
            angle_1=(sin(length_a/length_b))*180/pi;
            angle_2=(sin(length_c/length_b))*180/pi;
        elseif  length_a>length_b && length_a>length_c
            angle_1=(sin(length_c/length_a))*180/pi;
            angle_2=(sin(length_b/length_a))*180/pi;
        end
     end

    colorRnd = rand([1 3]);
    RGBtriangle= insertShape(Canvas,'FilledPolygon',[pointRnd(1,1) pointRnd(1,2) pointRnd(2,1) pointRnd(2,2) pointRnd(3,1) pointRnd(3,2)],'color','colorRnd');

    imwrite(RGBtriangle,fullfile('imgs_shapes/triangle',['triangle_' num2str(ii,'%03i') '.jpg']  ))

    
    disp(['creating img db: ' num2str(ii/numImgInClass*100,'%.2f') ' %'])
end

```