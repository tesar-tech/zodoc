title: Tvorba sady obrázků různých geometrických tvarů
lead: Tvorba sady obrázků různých tvarů (např. kolečko nebo obdélník) pro učení CNN
Published: 2018-12-15
Tags: [matlab, imageset, shapes, random, transfer learning]
prerequisites: [Matlab]
Authors: [tesar-tech, strakka1]
---

Skript vytváří složku `imgs_shapes` a podsložky pojmenované po jednotlivých tvarech. Tvary odlišných barev, velikostí a pozic jsou generovány do těchto podsložek. Tato databáze obrázků má být použita pro trénování CNN k rozpoznávání tvarů.

``` matlab
numImgInClass = 10;%počet obrázků v každé třídě
imgSize= 227; %respektuje velikost vstupu pro alexnet
Canvas = zeros(imgSize);

mkdir('imgs_shapes');% vytvoření složek pro ukládání tvarů
mkdir('imgs_shapes/circle');
mkdir('imgs_shapes/rectangle');
mkdir('imgs_shapes/triangle');

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
    
    disp(['creating img db: ' num2str(ii/numImgInClass*100,'%.2f') ' %'])
end

```