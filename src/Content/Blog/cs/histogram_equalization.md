title: Ekvalizace histogramu
lead: Vylepšit kontrast obrázku s pomocí (adaptivní) ekvalizace histogramu
Published: 2018-11-10
Tags: [matlab, histogram, contrast]
datazooFiles: [imgs/kytka256.jpg ]
prerequisites: [Matlab]
Authors: tesar-tech
---
``` matlab
B=imread('pout.tif'); % pout.tif je zabudovaný obrázek v Matlabu

subplot(3,2,1);imshow(B)
subplot(3,2,2);imhist(B) %zobrazit histogram

% image equalization
B_equalized = histeq(B);
subplot(3,2,3);imshow(B_equalized)%ekvalizovat histogram
subplot(3,2,4);imhist(B_equalized)

% adaptivní ekvalizace
B_adaptive_equalized = adapthisteq(B,'NumTiles',[2 2]);
% parameter [m n] specifikuje počet regionů do kterých se rozdělí obrázek a poté jednotlivě zpracuje

subplot(3,2,5), imshow(B_adaptive_equalized)
subplot(3,2,6), imhist(B_adaptive_equalized)
```