---
title: Split and colorize channels of color image
lead: Display RGB channels from color image as three different RGB images
published: 2018-11-13
tags:  [matlab, RGB, colors]
prerequisites: [Matlab]
authors: tesar-tech
---

This post is an improvment of [previous one](split_and_display_channels_of_color_image). Channels are colorized by setting values of other channels to zero.

```matlab
A = imread('kytka256.jpg');
R1=A;G1=A;B1=A; %create new copies of original image

R1(:,:,[2,3])=0;
G1(:,:,[1,3])=0;
B1(:,:,[1,2])=0;

subplot 221;imshow(A);title('Original');
subplot 222;imshow(R1);title('Red');
subplot 223;imshow(G1);title('Green');
subplot 224;imshow(B1);title('Blue');
```


