title: Image segmentation in HSV color space
Description: How to isolate parts of similar color in an image
---
>This document utilizes [image of flower](../media/kytka256.jpg) in variable `A`
  
Isolate part of an image in HSV color space (which describes colors by hue, saturation, and value). Hue thresholds define a range of hues to isolate. For color-based segmentation, it's easier to manipulate images in HSV color space, because the hue channel is the mix of all RGB channels and it better distinguishes between all individual colors.

![](../media/2018-11-28-16-41-35.png)

``` matlab
% Load base image
A = imread('kytka256.jpg');
% Convert RGB values to HSV
imgHSV = rgb2hsv(A);
% Set thresholds for hue channel in range of 0 to 1
hueMin = 0.000; % 0 corresponds to red
hueMax = 0.280; % 0.28 is roughly yellow
% Mask creation from hue thresholds (hue is the first channel)
hueMask = (imgHSV(:,:,1) >= hueMin ) & (imgHSV(:,:,1) <= hueMax);
% Apply mask on original image to desaturate background
% (element-wise multiplication of second channel (saturation) and mask)
imgHSV(:,:,2) = imgHSV(:,:,2) .* hueMask;
% Display result
imshow(imgHSV);
```