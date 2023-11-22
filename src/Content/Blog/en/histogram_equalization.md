---
title: Histogram equalization
lead: Enhances the contrast of the image by (adaptive) histogram equalization
published: 2018-11-10
tags: [matlab, histogram, contrast]
datazooFiles: [imgs/kytka256.jpg ]
prerequisites: [Matlab]
authors: tesar-tech
---
``` matlab
B=imread('pout.tif'); % pout.tif is Matlab built-in image 

subplot(3,2,1);imshow(B)
subplot(3,2,2);imhist(B) %show image histogram

% image equalization
B_equalized = histeq(B);
subplot(3,2,3);imshow(B_equalized)%equalize image histogram
subplot(3,2,4);imhist(B_equalized)

% adaptive image equalization
B_adaptive_equalized = adapthisteq(B,'NumTiles',[2 2]);
% parameter [m n] specifies number of tiles image is divided into for processing

subplot(3,2,5), imshow(B_adaptive_equalized)
subplot(3,2,6), imhist(B_adaptive_equalized) 
```

