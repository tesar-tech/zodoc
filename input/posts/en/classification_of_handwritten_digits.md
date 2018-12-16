title: Classification of handwritten digits
lead: Select ROI from image and let it classify by CNN trained on MNIST dataset
Published: 2018-11-13
Tags: [matlab, MNIST, classification, handwritten, digits]
datazooFiles: [imgs/cisla_ver.jpg, models/MNIST_99.29.onnx ]
prerequisites: [Matlab,Matlab onnx support add-on]
Authors: tesar-tech
---

Model in onnx format was trained on [MNIST](http://yann.lecun.com/exdb/mnist/) dataset with 99.29 % accuracy.

The code runs in a loop. Firstly, select region with a single digit. This region is adjusted, resized and convolutional neural network is used to classify it.

``` matlab
%% import MNIST cnn
net = importONNXNetwork('MNIST_99.29.onnx','OutputLayerType',...
    'classification','classnames',{'0', '1', '2', '3', '4', '5' ,'6', '7', '8', '9'});
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