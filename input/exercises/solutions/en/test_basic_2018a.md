title: Basic knowledge test 2018a
--- 
# Eclipse of a square moon
 ``` matlab
vektor=uint8([0:2:255 255:-2:0]); % 0:255 represents gradual tones of colors from black to white, 255:0 - from white to black
% 2 and -2 are step's sizes
plocha = repmat(vektor,256,1); % This function returns a matrix, which contains 256 rows of 1x copy of the vector on each row
plocha(128-20:128+20,128-20:128+20)=100; % Creating a gray square
imshow(plocha);
 ```
# Two binary images
 ``` matlab
A_seda=rgb2gray(A); % Conversion to a grayscale image
bila = find(A_seda>128);
cerna = find(A_seda<128);
A_seda(bila)=255;
A_seda(cerna)=0;

A_seda2=rgb2gray(A);
A_seda2(bila) = 0;
A_seda2(cerna)=255;
subplot(2,1,1); imshow(A_seda);
subplot(2,1,2) ;imshow(A_seda2);
 ```
# The quartering
 ``` matlab
A_ctvrt1=A(1:128,1:128,:); %Selects the upper left quarter of the image
A_ctvrt2=A(128:256,1:128,:); % Selects the lower left quarter of the image
A_ctvrt3=A(1:128,128:256,:); % Selects the upper right quarter of the image
A_ctvrt4=A(128:256,128:256,:); % Selects the lower right quarter of the image
subplot(2,2,1);imshow(A_ctvrt1)
subplot(2,2,2);imshow(A_ctvrt3)
subplot(2,2,3);imshow(A_ctvrt2)
subplot(2,2,4);imshow(A_ctvrt4)
 ```
# The quartering - any size of the image
 ``` matlab
velikost=size(A); % This function return vector, which contains the size of the matrix A
polovina_delka=round(velikost(1)/2); % Rounding for the images of the odd length or width
polovina_sirka=round(velikost(2)/2);
A_ctvrt1=A(1:polovina_delka,1:polovina_sirka,:);
A_ctvrt2=A(polovina_delka:end,1:polovina_sirka,:);
A_ctvrt3=A(1:polovina_delka,polovina_sirka:end,:);
A_ctvrt4=A(polovina_delka:end,polovina_sirka:end,:);
subplot(2,2,1);imshow(A_ctvrt1)
subplot(2,2,3);imshow(A_ctvrt2)
subplot(2,2,2);imshow(A_ctvrt3)
subplot(2,2,4);imshow(A_ctvrt4)
 ```

