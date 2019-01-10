title: Generování náhodných hvězdiček
lead: Tvorba sady obrázků tvaru pěticípé hvězdy pro učení CNN
Published: 2019-01-09
Tags: [matlab, imageset, shapes, random, transfer learning]
prerequisites: [Matlab]
Authors: [tesar-tech, magias]
---


Skript vytváří složku `imgs_shapes/star`. Podobně jako tento [skript](https://zodoc.netlify.com/posts/en/creating_an_image_set_with_various_shapes). Generuje pravidelné pěticípé hvězdy odlišných barev, velikostí a pozic do této složky. Tato databáze obrázků má být použita pro trénování CNN k rozpoznávání tvarů.


```matlab
dir = mkdir('imgs_shapes/star');
numImg = 10;
imgSize= 227; % velikost vstupu pro alexnet
stepSize = 360 / 5; %úhel pro pravidelné pětiúhelníky
angles1 = 0 : stepSize : 360; %úhly pro prvni pětiúhelník
angles2 = stepSize/2 : stepSize : 360 + stepSize/2; %úhly pro prvni pětiúhelník

for i=1:numImg
%Náhodna velikost obou pětiúhelníků
r1 = randi([10 30],1);
r2 = randi([40 80],1);

%Vygenerovaní souřadnic pro oba pětiúhelníky
x1 = r1 * cosd(angles1);
y1 = r1 * sind(angles1);
x2 = r2 * cosd(angles2);
y2 = r2 * sind(angles2);

%Překreslení souřadnic otočených pětiúhelníků do polygonu tvaru hvězdy
x3 = reshape([x1;x2], 1, []);
y3 = reshape([y1;y2], 1, []);

% Přesun souřadnic doprostřed
x3 = x3+imgSize/2;
y3 = y3+imgSize/2;

% Náhodný posun
x3 = x3+randi([-round(min(x3)) (imgSize - round(max(x3)))],1);
y3 = y3+randi([-round(min(y3)) (imgSize - round(max(y3)))],1);

% Uděla masku 227x227 binárního obrazu ze souřadnic polygonu ve tvaru hvězdy
maskImage = poly2mask(x3, y3, imgSize, imgSize);

%random úhel pro rotaci
angleRand=randi([0 360],1);

%otočení obrazu zanechání velikosti
rotateImg = imrotate(maskImage,angleRand,'crop');

%jednokanálová bíla hvězda
whiteImage = 255 * uint8(rotateImg);

%náhodný generator barevných kanálů
RRand=randi([0 255],1);
GRand=randi([0 255],1);
BRand=randi([0 255],1);

%vytvoření RGB obrázku každý kanál má náhodnou sílu své barvy
RGB = cat(3, whiteImage-RRand, whiteImage-GRand, whiteImage-BRand);
imwrite(RGB,fullfile('imgs_shapes/star',['star_' num2str(i,'%03i') '.jpg']  ))

end
```