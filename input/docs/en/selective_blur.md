title: Selective blur
Description: How to blur background only
---
>This document utilizes [image of flower](../media/kytka256.jpg) in variable `A`
  
Blur only part that is not the flower itself. In fact, the entire image is blurred, and foreground is replaced by the original image.

![](../media/2018-11-03-09-44-29.png)

``` matlab
Abin = uint8(rgb2gray(A)>128);% thresholding of image

f_gaussian = fspecial('gaussian',20,4); % gaussian filter
A_gaussian = imfilter(A,f_gaussian,'same');% applying filter. 'same' size of image after filtration.
Abin_rgb = repmat(Abin,[1 1 3]);%replication of binary image to 3 dimensions (to be able to multiply RGB image)
A_selective_blur = Abin_rgb.*A + (1-Abin_rgb).*A_gaussian; %unblurred part + blurred part

imshow(A_selective_blur)
```