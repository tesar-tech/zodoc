title: Test základních znalostí 2
--- 
>This document works with image: 

* [Image of flower](media/test_basic_2_7) in `A` 

# Kytka v prostředku
 ``` matlab
 A = imread('test_basic_2_7.jpg');
 subplot (3,3,5); 
 imshow(A)
 ```
# Dvojkytka
 ``` matlab
Double_A = [A, A];
imshow(Double_A)
 ```
# Šedivý pruh
 ``` matlab
A_gray = rgb2gray(A);
As = A;
Lane = A_gray(150:180,:,:);
As(150:180,:,:) = repmat(Lane,[1 1 3]);
imshow(As);
 ```
# Průměr v rozsahu
 ``` matlab
Ap = A_gray;
ChoosenPixels = A_gray<220 & A_gray>120;
Ap(ChoosenPixels) = mean(A_gray(ChoosenPixels));
imshow(Ap)
 ```
# Gradient
 ``` matlab
Gradient_vector = 0:255;
Gradient = repmat(Gradient_vector,[256 1 ]);
imshow(Gradient,[])
 ```
# Kytkostín
 ``` matlab
Astin = double(A) + repmat(Gradient,[1 1 3]);
imshow(mat2gray(Astin))
 ```



