title: Hello World solution

---
# Introduction
Solution is mainly source code writen in english.
``` matlab
clc;
clear all; 
%% this is matlab comment
A = zeros(100);% create square matrix (binary image)
A(50:70, 70:90) = 1; % place white square
A = imrotate(A,42)% rotate image by 42 °
imshow(A); % show image
```


