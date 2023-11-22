---
title: Reduce the number of colors by converting to indexed image
lead: Load an image and convert it to index image with lower number of colors
published: 2018-11-10
Tags: [matlab,indexed image, colors]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---

``` matlab
A=imread('kytka256.jpg');
[AInd,map]=rgb2ind(A,7); % 7 colors
imshow(AInd, map); %Every row from map refers to one color in RGB format (3 columns)
 ```

