title: Rotace obrázku pomocí transformační matice
--- 
>Tento dokument pracuje se jedním obrázkem:

* [Obrázek kytky](../media/kytka256.jpg) v proměnné `A` 

Transformační matice T je matice o velikosti 3x3, která se používá k provedení operace posunu, rotaci a změny měřítka v afinní transformaci 2D obrázků vůči původním souřadnicím osy.

 ![](../media/2018-11-23-18-23-33.jpg) 

Rotace je jedním z případu afinních transformací. Provádí se otáčením kolem počátku soustavy souřadnic o orientovaný úhel nastavující se pomocí transformační matice.Transformační matice slouží k nastavení hodnot parametrů uhlů, díky kterým se určuje o kolik stupňů se posune výsledný obrázek vůči jeho původní poloze.

T matice se nastavuje podle směru otáčení obrázku, což ovlivňuje hodnotu uhlu, o který se provádí rotace.

		T = ( cos(-φ) -sin(-φ)   = (  cos(φ) sin(φ)  
		      sin(-φ)  cos(-φ) )	 -sin(φ) cos(φ) )

Funkce affine2d(T) přirázuje matici vlastnosti platnou afinní transformací matice T.

Výsledná afinní transformace je výsledkem násobení matice původních souřadnic obrázku a transformační matice pro rotaci podle principu násobeni řádku na sloupec. Počet sloupců transformační matice musí odpovídat počtu řádků matice původní polohy obrázku.

		J =  (cos(φ) -sin(φ)   *  A
			  sin(φ)  cos(φ) )

V matlabu se provádí pomoci funkci imwarp(), kde se obrázek mění podle definovaného formátu rotaci.

						   		 
---				
```
 ``` matlab
A = rgb2gray(imread('kytka256.jpg')); %načítání obrázku a převedení do šedotonu
angle = pi/4; %uhel pi je určen pro zadávaní centrální symetrie vzhledem k původním souřadnicím osy

T = [  cos(angle) sin(angle) 0; %matice T o velikosti 3x3 nastavuje afinní transformaci roviny
      -sin(angle) cos(angle) 0; %cos(uh) ,sin(uh), -sin(uh), cos(uh) zadávají uhly otáčení obrázku kolem své osy pro provedení rotaci
	        0         0      1 ]; %poslední řadek {0 0 1} určuje posun obrázku podél os X a Y(pro translation = posun)
                                                 
tform = affine2d(T); %nastavuje vlastnosti matice T s platnou afinní transformací pro maticí tform
J = imwarp(A,tform); %transformuje obrázek A podle geometrické transformace s definovaným formátem v tform

montage([{A},{J}]); %zobrazuje původní a transformovaný obrázky do jedného snímku

