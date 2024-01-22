---
title: Randomly two-color image
lead: From RGB to randomly two-color image
Published: 2018-11-12
Tags: [matlab, binary image, RGB,random]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---

Converts image to binary representation and dyes it with two random colors. The code ensures that the colors and channel values will never be the same.

``` matlab
A=imread('kytka256.jpg');
Ag = rgb2gray(A);% covert to grayscale
colors = randperm(256,6) -1;% get 6 random numbers from 0 to 255
Ab = imbinarize(Ag);%convert to binary image
Ab_3D = repmat(Ab,[1 1 3]);%replicate binary image to 3 dimensions
R = Ab*colors(1) + ~Ab*colors(2);% 1 * color = color
G = Ab*colors(3) + ~Ab*colors(4);
B = Ab*colors(5) + ~Ab*colors(6);
Ab_RGB = cat(3,R,G,B);%merging in 3th dimension

imshow(uint8(Ab_RGB));
```
