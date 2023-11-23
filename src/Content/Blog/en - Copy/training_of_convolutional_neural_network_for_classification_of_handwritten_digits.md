---
title: Training of convolutional neural network for classification of handwritten digits
lead: Specify layers and training options and use matlab build-in digit data set for CNN training.  
Published: 2018-12-20
Tags: [matlab, training ,MNIST, classification, handwritten, digits]
prerequisites: [Matlab]
Authors: tesar-tech
---

This post is a simple example of CNN training. It uses the uncomplicated layer structure and training options for keeping things as simple as possible. The structure is simple enough to be trained fast on common CPU. Accuracy of trained network is over 98 %. [Another post](classification_of_handwritten_digit) describes how to use this network to classify your own handwritten digit.
  
``` matlab
%% load data
%path to build-in digits dataset (part of MNIST dataset)
digitDatasetPath = fullfile(matlabroot,'toolbox','nnet', 'nndemos','nndatasets', 'DigitDataset');
imds = imageDatastore(digitDatasetPath, 'IncludeSubfolders', true, 'LabelSource', 'foldernames');
%Split data to train and test parts
[imdsTrain, imdsValidation] = splitEachLabel (imds, 0.7, 'randomize');

%% constructing cnn layer by layer
layers = [
    imageInputLayer([28 28 1]) % input layer (grayscale image with size of 28x28 pixels)
    convolution2dLayer(5,16,'Padding', 'same') % 16 convolution filters with size of 5
    batchNormalizationLayer % normalization layer
    reluLayer %relu for additional non-linearity (input lower than 0 is changed to 0, otherwise it still unchanged)
    
    fullyConnectedLayer(10) % 10 - number of neurons 
    softmaxLayer % normalization
    classificationLayer 
];

%% specify options
options = trainingOptions('sgdm',...% type of solver
    'Verbose', false,...% dont output in command window
    'Plots', 'training-progress',...% plot nice graph with training progress
    'MaxEpoch',5,...%use every training image 5 times
    'ValidationData', imdsValidation); % use validation data 

%% train network 
net = trainNetwork (imdsTrain, layers, options); % training of CNN

```
