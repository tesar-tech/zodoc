title: Histogram-based operations on images
Description: Histogram plotting, histogram based equalization, deequalization. Creating tool for interactive partial highlighting of teeth x-ray
---
>This document works with three images: 
* [image](/zodoc/assets/img/rip_histogramy.jpg) in `A` variable
* matlab default image pout.tif in `B` variable 
* [teeth x-ray image](/zodoc/assets/img/zubRtg.png) in `C` variable.
# Histogram plotting
```matlab
A=imread('rip_histogramy.jpg'); % loading an image
As=rgb2gray(A); % conversion to grayscale
H = imhist(As); % histogram
subplot(2,1,1)
imshow(A) % original picture
subplot(2,1,2)
imhist(As) % histogram display
```
![](media/hist1_rip.png)
