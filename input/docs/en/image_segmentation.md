title: Image segmentation in HSV colorspace
Description: How to isolate parts of similar color in an image
---
>This document utilizes [image of flower](../media/kytka256.jpg) in variable `A`
  
Isolate part of an image in HSV colorspace. Hue thresholds in range of 0 to 1 define a slice of hues to isolate. It's easier to manipulate an image in HSV colorspace rather than RGB. The hue channel of HSV encompasses the whole RGB colorspace.

![](../media/2018-11-28-16-41-35.png)

``` matlab
%% Convert RGB values to HSV
imgHSV = rgb2hsv(A);
%% Define thresholds for hue channel
hueMax = 0.280;
hueMin = 0.000;
%% Mask creation from hue thresholds
hueMask = (imgHSV(:,:,1) >= hueMin ) & (imgHSV(:,:,1) <= hueMax);
%% Apply hue mask on original image
imgHSV(:,:,2) = imgHSV(:,:,2) .* hueMask;
```