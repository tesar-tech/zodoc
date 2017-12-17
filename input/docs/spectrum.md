title: Image spectra, fourier transformation, low-pass and high-pass filter
Description: Plotting basic functions and their spectrums, calculating and showing spectrums of grayscale images using 2D fourier transformation, creating low-pass filter and high-pass filter and plotting results 
---
>This whole document works with [image](/zodoc/assets/img/kytka256.jpg) in `A` variable.
# One-dimensional signal spectrum - sine function, dirac delta function, constant function
## Calculating functions and their spectra
```matlab
x_sin=0:pi/64:2*pi; % creating the signal - sine function
y_sin=sin(x_sin);

x_dirac=1:10; % creating the signal - dirac delta function
y_dirac=zeros((length(x_dirac)),1);
y_dirac(length(x_dirac)/2)=1;

x_konst=x_dirac;  % creating the signal - const function
y_konst=ones(length(x_dirac),1);

% spectrum calculation using Fast fourier tranform
sp_sin= fft(y_sin); 
sp_dirac=fft(y_dirac); 
sp_konst=fft(y_konst); 

%standardized frequency axis
faxis_sin = linspace(0, 1, length(sp_sin)); 
faxis_dirac = linspace(0, 1, length(sp_dirac)); 
faxis_konst = linspace(0, 1, length(sp_konst)); 
```
## Ploting results
``` matlab
subplot(3,2,1) 
plot(x_sin,y_sin)
title('sine function')
subplot(3,2,2)
stem(faxis_sin, abs(sp_sin), '.')
title('sine function spectrum')
subplot(3,2,3)
stem(x_dirac,y_dirac)
title('dirac delta function')
subplot(3,2,4)
stem(faxis_dirac, abs(sp_dirac), '.')
title('dirac delta function spectrum ')
subplot(3,2,5)
plot(x_konst,y_konst)
title('constant function')
subplot(3,2,6)
stem(faxis_konst, abs(sp_konst), '.')
title('constant function spectre')
```
![](media/spect1.png)
#
``` matlab
close all
num_points = 256;
corr_iron = sin(linspace(1,50,num_points)); % vytvori sinusovy signal s poctem bodu si, linspace vytvori vektor s hranicemi 1 a 50 a poctem bodu si
A = repmat(corr_iron, num_points, 1); % vytvori matici, ktera vznikne spojenim sin_plech v pocet_bodu-krat

figure
subplot(1, 2, 1)
imshow(A, [])
title('corrugated iron ')
% vypocet spektra

spektrum_obr = fft2(A); % vypocet spektra pomoci rychle fourierovy transformace pro 2D obraz

subplot(1, 2, 2)

imshow(fftshift(abs(spektrum_obr)), []) % posouva nulove frekvence do stredu

title('spektrum')

% vysoke frekvence jsou na krajich, nulova ve stredu 
```
![](media/spect2_corr_iron.png)
#
``` matlab
%% fft na fotce - kvetina - DP a HP

A = (imread('kytka256.jpg'));

im_gr= rgb2gray(A);

% vypocet spektra sedotonoveho obrazku

spektrum_obr = fft2(im_gr);

spektrum_obr_uprava = log(fftshift(abs(spektrum_obr)));

subplot(3,3,1)

imshow(im_gr)

title('Original grayscale img')

subplot(3,3,2)

imshow(spektrum_obr_uprava, [])

title('spectrum')

% filtrace

im_size = size(im_gr); %rozmery obrazu

d = 20; % sirka intervalu pro ctverec binarni masky

maska_dp = zeros(im_size(1), im_size(2)); % tvorba masky

maska_dp((im_size(1)/2)-d:(im_size(1)/2)+d, (im_size(2)/2)-d:(im_size(2)/2)+d) = 1; % vytvoreni masky ze stredu

% filtrace dolni propusti

spektrum_filt_dp = fftshift(spektrum_obr) .* maska_dp; % predpis pro filtraci ve frekvenci oblasti, spektrum je vynasobeno maskou

img_dp = ifft2(spektrum_filt_dp); %zpetna fourierova transformace

% vykresleni vysledku filtrace DP

subplot(3, 3, 4)

imshow((abs(img_dp)), []),title('after low-pass filter')

title('after low-pass filter')

subplot(3,3,5)

imshow(log(abs(spektrum_filt_dp)), [])

title('spectrum')

subplot(3, 3, 6)

imshow(maska_dp)

title('mask')

% pouziti inverzni masky, horni propust

spektrum_filt_hp = fftshift(spektrum_obr) .* (~maska_dp);

img_hp = ifft2(spektrum_filt_hp); %zpetna fourierova transformace

% vykresleni vysledku filtrace HP

subplot(3, 3, 7)

imshow((abs(img_hp)), []),title('after high-pass filter')

title('after high-pass filter')

subplot(3,3,8)

imshow(log(abs(spektrum_filt_hp)), [])

title('spectrum')

subplot(3, 3, 9)

imshow(~maska_dp)

title('mask') 
```
![](media/spect2.png)

