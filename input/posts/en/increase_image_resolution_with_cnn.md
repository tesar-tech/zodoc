title: Increase Image Resolution with CNN 
lead: Testing Very-Deep Super-Resolution (VDSR) neural network.
Published: 2018-10-13
Tags: [matlab, super-resolution, vdsr]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---
*real results are slightly different beacause of gif conversion*

This is a test of the method described in [matlab documentation](https://www.mathworks.com/help/images/single-image-super-resolution-using-deep-learning.html). You can see slight improvement in image quality over bicubic interpolation.

``` matlab
%% import pretrained net provided by matlab
load('trainedVDSR-Epoch-100-ScaleFactors-234.mat');

%% prepare imgs
A_ref = im2double(imresize(imread('imgs/kytka256.jpg'),[255 255]));
scaleFactor = 3;
A = imresize(A_ref,1/scaleFactor);
A_bicubic = imresize(A,scaleFactor,'bicubic');

%% create HR image by VDSR
A_ycbcr = rgb2ycbcr(A_bicubic);% convert to Ycbcr color space 
%resolution recosnstruction is done only on luminance channel
A_residual = activations(net,A_ycbcr(:,:,1),41);% 1st channel is Y(luminance)

A_y_vsdr = A_ycbcr(:,:,1)+A_residual;% Y channel by vdsr
A_vdsr = ycbcr2rgb(cat(3,A_y_vsdr,A_ycbcr(:,:,2),A_ycbcr(:,:,3)));%covert back to rgb

%% add text and play as movie
Movie(:,:,:,1) =insertText(A_bicubic,[1 1],'HR by bicubic','TextColor','white','BoxOpacity',0); 
Movie(:,:,:,2) =insertText(A_vdsr,[1 1],'HR by VDSR','TextColor','white','BoxOpacity',0); 
Movie(:,:,:,3) =insertText(A_ref,[1 1],'Reference img','TextColor','white','BoxOpacity',0); 
implay(Movie,1);
```