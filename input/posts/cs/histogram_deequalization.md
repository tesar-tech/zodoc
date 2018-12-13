title: ' "Deekvalizace" histogramu - snížení kontrastu'
lead: Snížení kontrastu obrazu s pomocí jednoduché matiky
Published: 2018-11-10
Tags: [matlab, histogram, contrast]
datazooFiles: [imgs/kytka256.jpg ]
prerequisites: [Matlab]
Authors: tesar-tech
---

``` matlab
Ag = rgb2gray(imread('kytka256.jpg'));

subplot(2,2,1);imshow(Ag)
subplot(2,2,2);imhist(Ag)

Dq=(Ag*0.2)+100; % deeqkvalizace
subplot(2,2,3);imshow(Dq)
subplot(2,2,4);imhist(Dq) 
```
