title: Handwritten numbers to binary image
Description: Conversion of handwritten numbers on a paper to binary image
---
>This document utilizes [image](/zodoc/assets/img/cisla_ver.jpg) stored in variable `A`.

Convert the image to binary representation where numbers are going to be represented in white color, while the background is going to be black. However, the numbers won't be very clearly visible for possible future classification by neural networks, so a mathematical morphology operation called dilation will be used, implemented in MATLAB with function `imdilate`.

![](../media/2018-11-14-02-33-30)

```matlab
A = imread('cisla_ver.jpg'); % load an image
AGray = rgb2gray(A); % conversion to grayscale
ABinary = imbinarize(AGray, 'adaptive', 'ForegroundPolarity', 'dark', 'Sensitivity', 0.3); % binarization of image. ForegroundPolarity parameter indicates that the foreground is darker than the background.
ABinaryComplement = ~ABinary; % turning numbers to white color
StructuringElement = strel('disk', 7); % creating a disk-shaped structuring element to probe the binary image
DilatedABinaryComplement = imdilate(ABinaryComplement, StructuringElement); % dilation of image
subplot(1, 2, 1), imshow(ABinaryComplement)
subplot(1, 2, 2), imshow(DilatedABinaryComplement)
```