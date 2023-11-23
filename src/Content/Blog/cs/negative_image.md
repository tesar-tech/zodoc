title: Negativ obrázku
lead: Vytvořit negativ obrázku
published: 2018-11-09
Tags: [matlab, negative]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---

``` matlab
A=imread('kytka256.jpg');
An= 255-A;%pokud je obrázek typu uint8
%nebo
An=imcomplement(A);
imshow(An)
 ```
