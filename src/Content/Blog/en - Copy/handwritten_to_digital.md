---
title: Handwritten numbers to binary image
lead: Conversion of handwritten numbers on a paper to binary image
published: 2018-11-14
Tags: [matlab,binary image, classification, handwritten, digits]
datazooFiles: imgs/cisla_ver.jpg,
prerequisites: Matlab
Authors: tesar-tech
---

Convert the image to binary representation where numbers are going to be represented in white color, while the background is going to be black. However, the numbers won't be very clearly visible for possible future classification by neural networks, so a mathematical morphology operation called dilation will be used, implemented in MATLAB with function `imdilate`.

```matlab
A = imread('cisla_ver.jpg'); % load an image
AGray = rgb2gray(A); % conversion to grayscale
ABinary = imbinarize(AGray, 'adaptive', 'ForegroundPolarity', 'dark', 'Sensitivity', 0.3); % binarization of image. ForegroundPolarity parameter indicates that the foreground is darker than the background.
ABinaryComplement = ~ABinary; % turning numbers to white color
StructuringElement = strel('disk', 7); % creating a disk-shaped structuring element to probe the binary image
DilatedABinaryComplement = imdilate(ABinaryComplement, StructuringElement); % dilation of image
subplot(1, 3, 1), imshow(A)
subplot(1, 3, 2), imshow(ABinaryComplement)
subplot(1, 3, 3), imshow(DilatedABinaryComplement)
```
