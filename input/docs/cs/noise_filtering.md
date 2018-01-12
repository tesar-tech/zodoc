title: Filtrování šumu.
---
>This document works with two images:
* [Image of Norway with noise](../media/nor256_noise.png) in `A` 
* [Image of Norway](../media/nor256.jpg) in `B`
# Prozkoumání šumu
``` matlab
A = imread('nor256_noise.png');
B = rgb2gray(imread('nor256.jpg'));
Noise = A ( A~=B );
imhist(Noise) %funkce zobrazí histogram.
```
# Gaussianová konvoluce.
``` matlab 
h = fspecial('gaussian',[3 3]); % funkce vytvoří masku pro filtrování 
Aa = imfilter(A,h,'conv'); %  provádí filtraci obrazových dat
Ab = conv2(double(A),h,'same');
```
# Medianový filtr
``` matlab
isNoise = (A==255 | A==0); % vybere černé a bilé body z obrázku(šum)
MedianFilter = medfilt2(A); %medianový filtr s maskou 3x3
F = A;
F(isNoise) = MedianFilter(isNoise); % nahrazení vadných pixelu medianovou hodnotou
imshow(F); 
immse2=@(x,y)sum(sum((double(x) - double(y)).^2))/numel(x); %Kontrola MSE 
%Vykresleni grafu
close all
errnum = 1;
labels_X =[];err=[];
err(errnum) = immse2(B, A);labels_X{errnum} ='Šum';errnum= errnum+1;
err(errnum) = immse2(B, F);labels_X{errnum} ='Upravený medfilt';errnum= errnum+1;
bar(err)
set(gca,'XTickLabel',labels_X) % nastaví text na osu x 
text(1:length(err),err',num2str(err','%0.2f'),'HorizontalAlignment','center','VerticalAlignment','bottom') % zobrazení čísel na bary
```
![](../media/noisemedfil.png)
# Histogram gaussovského šumu
``` matlab
A_noise = imnoise(B, 'gaussian'); % gausuv šum na obrázek
A_orig = double(A_noise)- double(B); % odčítání matic
hist(A_orig(:),22); % histogram, vykreslení vektoru
xlabel('Velikost šuma'), ylabel('Četnost')
```
![](../media/histnoise.png)
# Testování filtrů
``` matlab
A_noise = imnoise(B,'gaussian'); % gausuv šum na obrázek
AVR=fspecial('average', [3,3]);
GAU=fspecial('gaussian',[3,3], 0.5);
R = imfilter(A_noise, AVR); %average filtr
T = imfilter(A_noise, GAU); %gaussian filtr
W = wiener2(A_noise); 
% vykresleni grafu
close all
errnum = 1;
labels_X = [];err=[];
err(errnum) = immse2(B, A_noise); labels_X{errnum} = 'Orig. noise'; errnum= errnum+1;
err(errnum) = immse2(B, R); labels_X{errnum} = 'Average filter'; errnum= errnum+1;
err(errnum) = immse2(B, T); labels_X{errnum} = 'Gaussian filter'; errnum= errnum+1;
err(errnum) = immse2(B, W); labels_X{errnum} = 'Wiener filter'; errnum= errnum+1;
hledani_velikosti_okna = [];
for k = 2:10
    hledani_velikosti_okna(k) = immse2(B, wiener2(A_noise, [k k]));
end
[~,indxmin] = min(hledani_velikosti_okna);
disp(['velikost okna s nejlepsim mse: ' num2str(indxmin+1) ])
bar(err)
set (gca, 'XTickLabel', labels_X) % nastaví text na osu x 
text(1:length(err),err',num2str(err','%0.2f'), 'HorizontalAlignment','center','VerticalAlignment','bottom') % zobrazení čísel na bary
```
![](../media/testfilter.png)