
Title: Klasifikace čísla pomocí natrénované sítě 
-
---

 Description: MNIST je velká databáze ručně psaných číslic, které se použivají pro školení různých systémů ve zpracování obrazu a taktéž ke školení a testování v oblasti strojového učení.
 
---
>Tento dokument pracuje s obrázkem:
[Obrázek číslice](.../media/trojka.png) v proměnné `img3`

  > Jelikož databáze MNIST má dannou normalizaci pro vzhled obrázku, tak musíme upravit obr. do požadované formy. 1, Obr. musí být černobílý o veliskoti (28x28) a tloušce čáry (2pixely). 2, Číslo musí být zarovnáno na střed. 3, Obr. musí být šedotónový.
  Viz. (trojka.png)
  #


``` matlab
%Import MNIST cnn
mnist = importONNXNetwork('MNIST_99.29.onnx','OutputLayerType','classification','ClassNames',{'0','1','2','3','4','5','6','7','8','9'}); 

%Načtení obrázku
img3 = imread('trojka.png');


%Změna velikosti (28x28)
img1 = imresize(img3,[28 28]);

%Konverze do šedotónu
trojkabw = rgb2gray(img1);



%Doplnění šedotónu do originálu
trojka = imcomplement(trojkabw);



%Klasifikace obrázku za pomocí CPU.(Využiti CPU pro trenování se zdá být rychlejší varianta, než GPU)**
[label, score] = classify(mnist,trojka,'ExecutionEnvironment','cpu');
disp(label);

``` 
