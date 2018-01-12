title: Test základních znalostí 1
---
>This document works with two images: 

* [Image of flower](media/test_basic_1_7.jpg) in `A` 
* [Image of Norway](media/tes_basic_1_8.jpg) in `B`
# Kytka
 ``` matlab
A = imread('test_basic_1_7.jpg');
A_gray = rgb2gray(A);
subplot (2,2,1); imshow(A)
subplot (2,2,4) ;imshow(A_gray)
 ```
# Kytkonor
 ``` matlab
B = imread('test_basic_1_8.jpg');
Flower = A;
Two_images = cat (3,Flower(:,:,2),B(:,:,1),B(:,:,3));
imshow(Two_images)
 ```
 # Světlejší
 ``` matlab
Highlight = A;
Highlight(128:end,:,:) = Highlight(128:end,:,:)+100;
imshow(Highlight)
 ```
# Křížem
 ``` matlab
K = A_gray;
K(100:120,20:220) =0;
K(20:220,100:120) =0;
imshow(K)
 ```
# Vysvětlená kytka
 ``` matlab
More = find(A_gray>128);
V = A_gray;
More = find(A_gray>128);
V(More) = 255;
imshow(V)
 ```
# Vybarvená květina
 ``` matlab
Less = find(A_gray<128);
R = A (:,:,1);
G = A (:,:,2);
B = A(:,:,3);
R(Less) =A_gray(Less);
G(Less) =A_gray(Less);
B(Less) =A_gray(Less);
ColorfulWhereMore = cat(3,R,G,B);
imshow(ColorfulWhereMore)
 ```



