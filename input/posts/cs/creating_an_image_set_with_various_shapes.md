title: Tvorba sady obrázků různých geometrických tvarů
lead: Tvorba sady obrázků různých tvarů (např. kolečko nebo obdélník) pro učení CNN
Published: 2018-12-15
Tags: [matlab, imageset, shapes, random, transfer learning]
prerequisites: [Matlab]
Authors: [tesar-tech, strakka1, magias]
---

Skript vytváří složku `imgs_shapes` a podsložky pojmenované po jednotlivých tvarech. Tvary odlišných barev, velikostí a pozic jsou generovány do těchto podsložek. Tato databáze obrázků má být použita pro trénování CNN k rozpoznávání tvarů.

``` matlab
numImgInClass = 10;%počet obrázků v každé třídě
imgSize= 227; %respektuje velikost vstupu pro alexnet
Canvas = zeros(imgSize);

stepSize = 360 / 5; %úhel pro pravidelné pětiúhelníky
angles1 = 0 : stepSize : 360; %úhly pro prvni pětiúhelník
angles2 = stepSize/2 : stepSize : 360 + stepSize/2; %úhly pro prvni pětiúhelník

mkdir('imgs_shapes');% vytvoření složek pro ukládání tvarů
mkdir('imgs_shapes/circle');
mkdir('imgs_shapes/rectangle');
mkdir('imgs_shapes/triangle');
mkdir('imgs_shapes/star');

for ii = 1:numImgInClass
    %% tvorba "náhodného" kolečka
    
    colorRnd = rand([1 3]);
    radiusRnd = randi([10 80],1);
    
    posRnd = randi([radiusRnd imgSize-radiusRnd],[1 2]);
    RGBcircle = insertShape(Canvas,'FilledCircle',[posRnd radiusRnd],'color',colorRnd);
    
    imwrite(RGBcircle,fullfile('imgs_shapes/circle',['circle_' num2str(ii,'%03i') '.jpg']  ))
    
    %% tvorba "náhodného" obdelníku
    colorRnd = rand([1 3]);
    heightHalfRnd = randi([10 80],1);
    widthHalfRnd = randi([10 80],1);
    
    posRnd = randi([1 imgSize-max(heightHalfRnd,widthHalfRnd)*2],[1 2]);
    RGBsquare = insertShape(Canvas,'FilledRectangle',[posRnd heightHalfRnd*2 widthHalfRnd*2],'color',colorRnd);
    
    imwrite(RGBsquare,fullfile('imgs_shapes/rectangle',['square_' num2str(ii,'%03i') '.jpg']  ))
    
    %% tvorba "náhodného" trojúhelníku
    %souřadnice a úhly musí splňovat tyto podmínky:
    %velikost úhlu >15 a každá strana >66 (kvůli příliš malým nebo úzkým trojúhelníkům), minimálně dvě "x" a "y" souřadnice musí být odlišné  
    
    alpha=0; beta=0; gamma=0; sides=[1,1,1]; point=[0 0; 1 1];
    while( rad2deg(alpha)<15 || beta<15 || gamma<15 || sum(sides(1,:)<66)>0  || numel(unique([point(1,1),point(2,1)]))==1 || numel(unique([point(1,2),point(2,2)]))==1 )
        point=randi([40 190],[3 2]); 
        sides=sort(pdist(point,'euclidean')); %Euklidovská vzdálenost mezi dvěma body = délka strany
        alpha=acos((sides(2).^2+sides(3).^2-sides(1).^2)/(2*sides(2) * sides(3))); %kosinová věta -> úhel alfa ve stupních
        beta=rad2deg(asin((sides(2)/sides(1))*sin(alpha))); %sinová věta -> úhel beta v radiánech
        gamma=180-beta-(rad2deg(alpha)); % úhel gama
    end
    
    point_vector=[point(1,:),point(2,:),point(3,:)];
    colorRnd = rand([1 3]);
    RGBtriangle= insertShape(Canvas,'FilledPolygon',point_vector,'color',colorRnd);
    
    imwrite(RGBtriangle,fullfile('imgs_shapes/triangle',['triangle_' num2str(ii,'%03i') '.jpg']  ))

    %% Tvorba Hvězd 
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
    imwrite(RGB,fullfile('imgs_shapes/star',['star_' num2str(ii,'%03i') '.jpg']  ))

    disp(['creating img db: ' num2str(ii/numImgInClass*100,'%.2f') ' %'])
end
```