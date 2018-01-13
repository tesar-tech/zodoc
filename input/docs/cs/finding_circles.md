title: Hledání kružnic - Houghova transformace
---
>Tento dokument pracuje s obrázkem: 

* [Obrázek oka](../media/oko.jpg) v proměnné `A` 
# Načtení obrázku jeho předzpracování a hledání hran
``` matlab
A = rgb2gray(imread('oko.jpg')); % převod obrázu do stupnice šedi
h = fspecial('gaussian',[8 8],1); % tvorba masky pro filtrování 
A_filter = imfilter(A,h); % provádí filtraci šumu
hrany = edge(A_filter); % funkce nalezne hrany v obrazu
subplot 131;imshow(A);title('původní obrázek');
subplot 132;imshow(A_filter);title('obrázek po filtraci');
subplot 133;imshow(hrany);title('hrany');
```
![](../media/plotedges.png)
# Algoritmus pro výpočet Houghovy transformaci
``` matlab
minR = 40; 
maxR = 46; 
ii = 0;
indexy_hran = find(hrany); 
[m, n] = size(A);
for r = minR:maxR % interval poloměru od 40 do 46
    ii= ii+1;
    platno = zeros(m,n); % pro každý poloměr jedno plátno
    tic % výpočetní čas - start
    for h = 1:length(indexy_hran)
        % generování kružnice
        matice_s_bodem = zeros(m,n); % pomocná matice na tvorbu kružnice
        matice_s_bodem(indexy_hran(h))=1; % na místě aktuálního hranového bodu udělá jedničku
        vzdalenosti_od_bodu = bwdist(matice_s_bodem); % propočítá vzdálenosti od nejbližší jedničky
        kruznice = round(vzdalenosti_od_bodu)==r; % vzdálenosti v délce poloměru
        platno = platno+kruznice; % přimaluje kružnici na plátno
    end
    toc % výpočetní čas - konec
    r
    vsechny_platna(:,:,ii)= platno; 
end
```
# Hledání maxima
``` matlab
[~, ind] = max(vsechny_platna(:)); % kde v kvádru všech pláten je nejvyšší hodnota
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