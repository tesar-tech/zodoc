---
title: Negative image
lead: Create negative of an image
published: 2018-11-09
tags: [matlab, negative]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
authors: tesar-tech
---

``` matlab
A=imread('kytka256.jpg');
An= 255-A;%if image is type of uint8
%or
An=imcomplement(A);
imshow(An)
 ```


