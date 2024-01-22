---
title: Animation of binary image with variable threshold
lead: Change threshold for image binarization and save animation as a gif
published: 2018-11-15
tags:  [matlab, binary image, animation, gif]
prerequisites: [Matlab]
authors: tesar-tech
---

``` matlab
Ag = rgb2gray(imread('kytka256.jpg'));
firstTime = 1;gifName = 'bw_anim.gif';
for ii = 1:5:256
   curr_img = (Ag<ii)*255;% or use imbinarize instead
   [A,map] = gray2ind(curr_img,2); % change to indexed image
   
    if firstTime ==1%save first frame in different manner
        imwrite(A,map,gifName,'gif','LoopCount',Inf,'DelayTime',0.001);
    firstTime = 0;
    else
        imwrite(A,map,gifName,'gif','WriteMode','append','DelayTime',0.001);
    end 
 end
```
