---
title: Selective blur
lead: How to blur background only
Published: 11/03/2018
Tags: [matlab, filters, gaussian, blur]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---
  
Blur only part that is not the flower itself. In fact, the entire image is blurred, and foreground is replaced by the original image.

``` matlab
Abin = uint8(rgb2gray(A)>128);% thresholding of image

f_gaussian = fspecial('gaussian',20,4); % gaussian filter
A_gaussian = imfilter(A,f_gaussian,'same');% applying filter. 'same' size of image after filtration.
Abin_rgb = repmat(Abin,[1 1 3]);%replication of binary image to 3 dimensions (to be able to multiply RGB image)
A_selective_blur = Abin_rgb.*A + (1-Abin_rgb).*A_gaussian; %unblurred part + blurred part

imshow(A_selective_blur)
```
