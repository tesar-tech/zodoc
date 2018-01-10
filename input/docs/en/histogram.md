title: Histogram-based operations on images
Description: Histogram plotting, histogram based equalization, deequalization. Creating tool for interactive partial highlighting of teeth x-ray
---
>This document works with three images: 

* [Image of flower](../media/kytka256.jpg) in `A` 
* Build-in *pout.tif* image in `B`
* [Teeth x-ray image](../media/zubRtg.png) in `C` 
# Histogram plotting

```matlab
A=imread('kytka256.jpg'); % loading an image 
Ag = rgb2gray(A);
subplot(1,2,1);imshow(Ag) % original picture
subplot(1,2,2);imhist(Ag) % histogram display
```
![](../media/2017-12-18-14-54-00.png)
# Histogram and equalized histogram
``` matlab
B=imread('pout.tif');%pout.tif is matlab built-in image 

subplot(2,2,1);imshow(B)
subplot(2,2,2);imhist(B)

% image equalization
subplot(2,2,3);imshow(histeq(B))
subplot(2,2,4);imhist(histeq(B)) % equalized histogram display 
```
![](../media/hist2_pout.png)
# Image "deequalization" - contrast lowering
``` matlab
subplot(2,2,1);imshow(Ag)
subplot(2,2,2);imhist(Ag)

Dq=(Ag*0.2)+100; % image equalisation via multiplication and addition
subplot(2,2,3);imshow(Dq)
subplot(2,2,4);imhist(Dq) 
```
![](../media/2017-12-18-14-57-53.png)
# Local contrast increase on teeth x-ray image
Enable user to pick a square and replacing it with equalized one

``` matlab
C=imread('zubRtg.png');
button=1; % button
x=300;y=300; % square size - smaller, better depiction
figure;
ax = axes; % picking up axes

while button==1 % left-click on button
    if x>100 && y >100 % excludinh picture margins
        z_ekv=C;
        z_ekv(x-100:x+100,y-100:y+100)=histeq(z_ekv(x-100:x+100,y-100:y+100));
        imshow(z_ekv,'Parent',ax)
    end
    
    [y,x, button]=ginput(1); %waiting for button press
end
```
![](../media/zubr_anim.gif)
## Adaptive equalization
``` matlab
subplot(2,1,1), imshow(C)
z_ekvadaptive=adapthisteq(C,'NumTiles',[100 100]); 
subplot(2,1,2), imshow(z_ekvadaptive) 
```
![](../media/hist5_zubr_adeq.png)
