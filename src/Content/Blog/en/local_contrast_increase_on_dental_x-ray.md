---
title: Local contrast increase on dental x-ray 
lead: Let user to pick up a region and replace it with equalized one
published: 2018-11-11
tags: [matlab, dental, x-ray, histogram, contrast]
datazooFiles: [imgs/dental_x-ray.png ]
prerequisites: [Matlab]
authors: tesar-tech
---

``` matlab
C=imread('dental_x-ray.png');
button=1; % button
x=300;y=300; % starting position
figure;
ax = axes; % picking up axes

while button==1 % left-click on button
    if x>100 && y >100 % excluding picture margins
        z_ekv=C;
        z_ekv(x-100:x+100,y-100:y+100)=histeq(z_ekv(x-100:x+100,y-100:y+100));
        imshow(z_ekv,'Parent',ax)
    end
    [y,x, button]=ginput(1); % waiting for button press
end
```


