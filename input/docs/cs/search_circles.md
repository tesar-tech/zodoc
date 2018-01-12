title: Hledání kružnic.
---
>This document works with image: 

* [Image of eye](../media/oko.jpg) in `img` 
# Načtení obrázku a zobrazení hran
``` matlab
A = rgb2gray(imread('oko.jpg'));
h = fspecial('gaussian',[8 8],1);
A_filter = imfilter(A,h);
hrany = edge(A_filter);
subplot 131;imshow(A);title('původní obrázek');
subplot 132;imshow(A_filter);title('obrázek po filtrace');
subplot 133;imshow(hrany);title('hrany');
```
![](../media/plotedges.png)
# Samotný algoritmus 
``` matlab
minR = 40;
maxR = 46;
ii = 0;
indexy_hran = find(hrany); 
[m, n] = size(A);
for r = minR:maxR
    ii= ii+1;
    platno = zeros(m,n); % pro každý poloměr jedno plátno
    tic
    for h = 1:length(indexy_hran)
        % generování kružnice
        matice_s_bodem = zeros(m,n); % pomocná matice na tvorbu kružnice
        matice_s_bodem(indexy_hran(h))=1; % na místě aktuálního hranového bodu udělá jedničku
        vzdalenosti_od_bodu = bwdist(matice_s_bodem); % propočítá vzdálenosti od nejbližší jedničky
        kruznice = round(vzdalenosti_od_bodu)==r; % vzdálenosti v délce poloměr
        platno = platno+kruznice; % přimaluje kružnici na plátno
    end
    toc
    r
    vsechny_platna(:,:,ii)= platno;
end
```
# Najít u jakého poloměru je maximum
``` matlab
[~, ind] = max(vsechny_platna(:)); % kde v tom kvádru je nejvyšší hodnota
[a, b, c] = ind2sub(size(vsechny_platna),ind); % indexy třech rozměru
nalezenyPolomer = c+minR-1; % v případě 1 by to byl ten nejmenší poloměr
``` 
# Vykreslení kružnice
``` matlab
matice_s_bodem = zeros(m,n);
matice_s_bodem(a,b)=1;
vzdalenosti_od_bodu = bwdist(matice_s_bodem);
kruznice = round(vzdalenosti_od_bodu)==nalezenyPolomer;
imshow(double(A)+kruznice*255,[]);
``` 
![](../media/drawcir.png)
