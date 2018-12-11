title: Classification of handwritten digit with CNN
lead: Load cnn in onnx format. Resize and classify an image
Published: 2018-12-11
Tags: [matlab, MNIST, classification, handwritten, digits]
datazooFiles: [imgs/single_handwritten_digit.png, models/MNIST_99.29.onnx ]
prerequisites: [Matlab,Matlab onnx support add-on]
Authors: tesar-tech
---
Model in onnx format was trained on [MNIST](http://yann.lecun.com/exdb/mnist/) dataset with 99.29 % accuracy.
  
``` matlab
mnist = importONNXNetwork('MNIST_99.29.onnx','OutputLayerType','classification','ClassNames',{'0','1','2','3','4','5','6','7','8','9'}); %Import MNIST cnn

A = rgb2gray(imread('single_handwritten_digit.png'));%Load an image and covert to grayscale
A_resized = imresize(A,[28 28]);%Resize to [28x28] to match cnn input layer

[label, score] = classify(mnist,trojka,'ExecutionEnvironment','cpu');%(there is some issue on GPU when using onnx models, so CPU is used here)
A_withText = insertText(A,[1 1], cellstr("classified as " +  string(label)+newline+ "("+ num2str(max(score)*100,'%0.2f %%)')) ,'FontSize',28); % add text with classifiaction results
imshow(A_withText)
```