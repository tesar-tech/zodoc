title: Creating an image set with various shapes 
lead: Generating imageset with different shapes like circle or rectangle for CNN learning
Published: 2018-12-15
Tags: [matlab, imageset, shapes, random, transfer learning]
prerequisites: [Matlab]
Authors: tesar-tech
---

``` matlab
numImgInClass = 10;%number of imgs in every class
imgSize= 227; %respect alexnet input size
Canvas = zeros(imgSize);

mkdir('imgs_shapes');% create folders for shapes
mkdir('imgs_shapes/circle');
mkdir('imgs_shapes/rectangle');

for ii = 1:numImgInClass
    %% create "random" circle
    
    colorRnd = rand([1 3]);
    radiusRnd = randi([10 80],1);
    
    posRnd = randi([radiusRnd imgSize-radiusRnd],[1 2]);
    RGBcircle = insertShape(Canvas,'FilledCircle',[posRnd radiusRnd],'color',colorRnd);
    
    imwrite(RGBcircle,fullfile('imgs_shapes/circle',['circle_' num2str(ii,'%03i') '.jpg']  ))
    
    %% create "ranadom" rectangle
    colorRnd = rand([1 3]);
    heightHalfRnd = randi([10 80],1);
    widthHalfRnd = randi([10 80],1);
    
    posRnd = randi([1 imgSize-max(heightHalfRnd,widthHalfRnd)*2],[1 2]);
    RGBsquare = insertShape(Canvas,'FilledRectangle',[posRnd heightHalfRnd*2 widthHalfRnd*2],'color',colorRnd);
    
    imwrite(RGBsquare,fullfile('imgs_shapes/rectangle',['square_' num2str(ii,'%03i') '.jpg']  ))
    
    disp(['creating img db: ' num2str(ii/numImgInClass*100,'%.2f') ' %'])
end

```