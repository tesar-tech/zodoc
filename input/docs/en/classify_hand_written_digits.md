title: Classification of handwritten digits
Description: Select ROI from image and let it classify by CNN trained on MNIST dataset
---
>Utilizing the [image](/zodoc/media/cisla_ver.jpg) with handwritten digits (you can use any image with digits). Pretrained CNN on [MNIST](http://yann.lecun.com/exdb/mnist/) dataset is necessary. You can download one with 99.29 % accuracy [here](https://github.com/tesar-tech/zodoc/blob/master/datazoo/MNIST_99.29.onnx).

The code runs in a loop. Firstly, select region with a single digit. This region is adjusted, resized and convolutional neural network is used to classify it.

![](../media/2018-11-13-10-20-40.gif)

``` matlab
%% import MNIST cnn
net = importONNXNetwork('MNIST_99.29.onnx','OutputLayerType', 'classification',...
    'classnames',{'0', '1', '2', '3', '4', '5' ,'6', '7', '8', '9'});
%% load images 
A_orig =imread('cisla_ver.jpg');
A_gray = rgb2gray(A_orig);%convert to gray
%%
imshow(A_orig);
while 1
    rect = drawrectangle();
    A_gray_selection = imcrop(A_gray,rect.Position);% crop selected rectangle
    A_gray_selection_resized = imadjust( 255 -(imresize(A_gray_selection,[28 28])));%
    cl = classify(net,(A_gray_selection_resized));% classify by cnn
    if(exist('te'))
        te.delete% delete existing text
    end
    te = text(10,160,['Classified as ' cellstr(cl)],'FontSize',14,'color','blue');
    rect.delete;
end
```