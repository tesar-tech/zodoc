---
title: Split and display channels of color image
lead: Display RGB channels from color image as three different gray images
Published: 2018-11-12
Tags:  [matlab, RGB, colors]
prerequisites: [Matlab]
Authors: tesar-tech
---

RGB image is composed of three color channels. This script decomposes those channels into own variables and displays them as grayscale images.

```matlab
A = imread('kytka256.jpg');
R=A(:,:,1);
G=A(:,:,2);
B=A(:,:,3);

subplot 221;imshow(A);title('Original');
subplot 222;imshow(R);title('Red');
subplot 223;imshow(G);title('Green');
subplot 224;imshow(B);title('Blue');
```

