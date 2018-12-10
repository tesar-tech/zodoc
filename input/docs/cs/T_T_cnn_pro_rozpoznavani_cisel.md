Title: Jednoduché cnn pro rozpoznávání čísel
Description: Tvorba a trénink cnn pro rozpoznávání čísel
---
>Tento dokument pracuje s [obrazkem cisla](/zodoc/assets/img/cislo.jpg) v proměnné `C`

/zodoc/assets/img/uvodni_obrazek_trenovaci_graf.jpg
  
Vysledný trénovací graf, kde je vyobrazen průběh tréninku. Můžeme zde zjisti přesnost tréninku, která byla 97,90 %. Graf zachycuje několik epoch, přičemž jedna epocha je úplný průchod celým datovým souborem.

![](../media/2018-12-10-03-05-29.png)

``` matlab
%% Nacteni dat
digitDatasetPath = fullfile(matlabroot,'toolbox','nnet', 'nndemos','nndatasets', 'DigitDataset');
imds = imageDatastore(digitDatasetPath, 'IncludeSubfolders', true, 'LabelSource', 'foldernames');
% Prvnim parametrem je vždy cesta, dale jsou zde určeny další volitelné parametry. Ulozistě dat obsahuje 10 000 obrazů číslic 0 až 9.
[imdsTrain, imdsValidation] = splitEachLabel (imds, 0.8, 'randomize');%Výstupem jsou dvě množiny a to imdsTrain (trénovací) a imdsValidation (validační)

%% Tvorba vrstev
layers = [
    imageInputLayer([28 28 1]) % Vstupní vrstva, jedná se o šedotónový obrázek.
    convolution2dLayer(5,16,'Padding', 'same') % Druhá vrstva je konvoluce, kde je uveden pocet konovlučních filtrů, výstup po konvoluci bude stejný.
    batchNormalizationLayer % Normalizační vrstva.
    reluLayer % V případě, že bude výsledek větší, než nula, tak bude vracet součet a v opačném případě, bude vracet nulu.
    
    % Vylepšení - opakováným přídáním těchto tří vrstev
    convolution2dLayer(5,32,'Padding', 'same')
    batchNormalizationLayer 
    reluLayer
    
    maxPooling2dLayer(2, 'Stride', 2) % Dvakrát zmenšení obrátku (další možnosti nastavená na max/min/průměr). Parametry jsou velikost čtverečku (2) a dále velikost kroku (2).
    fullyConnectedLayer(10) % Přijámá jedninný parametr a to počet volných neuronů. 
    softmaxLayer % Všechny pravděpodobnosti se posčítají do jedničky. 
    classificationLayer % Řekne nám o jaké číslo se jedná.

%% Možnosti
options = trainingOptions('sgdm', 'ValidationPatience', 5, 'Shuffle', 'every-epoch','InitialLearnRate', 0.001, 'Verbose', false, 'Plots', 'training-progress', 'MaxEpoch',3, 'ValidationData', imdsValidation); 
% Sgdm - použije  stochastický gradientní sestup s optimalizátorem hybnosti. Hledání minima v okolí, prohlédnutí přes lokální maximum.
% ValidationPatience - automatické zastavení pomocí ověření je vypnuto. Toto chování zabraňuje ukončení tréninku před dostatečným učením z dat.
% Shuffle, every-epoch - abychom předešli vyřazení stejných dat z jednotlivých epoch. 
% InitialLearnRate - počáteční rychlost učení. 
% Verbose- indikátor pro zobrazení informací o průběhu výcviku.
% Plots - obrázky zobrazené během tréninku.
% MaxEpoch - maximální počet epoch.
% ValidationData - validování dat. 

%% Výstup natrénované cnn sítě 
net = trainNetwork (imdsTrain, layers, options); % Přijímá architekturu sítě, data na ktercých trénuje a parametry trénování.

%%
C = imadjust (imcomplement (imresize ( rgb2gray (imread('cislo.jpg')),[28 28]))); % Upraví intenzity barev, změní velikost obrázku, převede na šedotónový obrázek a to vše provede s načteným obrázkem čísla.
classify(net, C) % Klasifikujte data pomocí vyškolené hluboké neuronové sítě.


```