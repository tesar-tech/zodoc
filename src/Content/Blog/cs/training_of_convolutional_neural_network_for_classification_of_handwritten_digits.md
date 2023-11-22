title: Trénování konvoluční neuronové sítě pro klasifikaci ručně psaných čísel
lead: Specifikovat vrstvy a možnosti trénování a použití databáze ručně psaných čísel pro trénink konvoluční neuronové sítě.
Published: 2018-12-20
Tags: [matlab, training ,MNIST, classification, handwritten, digits]
prerequisites: [Matlab]
Authors: tesar-tech
---
Tento příspěvek je jednoduchým příkladem trénování konvoluční neuronové sítě. Využívá nekomplikovanou strukturu a nastavení. Struktura je dostatečně jednoduchá, aby se síť dala natrénovat na běžném procesoru. Přesnost natrénované sítě je více než 98 %. [Jiný příspěvek](classification_of_handwritten_digit) vysvětluje použití této sítě ke klasifikaci vlastních ručně psaných čísel.
  
``` matlab
%% načíst data
%cesta k zabudovanému datasetu (jenž je součástí MNIST databáze)
digitDatasetPath = fullfile(matlabroot,'toolbox','nnet', 'nndemos','nndatasets', 'DigitDataset');
imds = imageDatastore(digitDatasetPath, 'IncludeSubfolders', true, 'LabelSource', 'foldernames');
%Rozdělení dat na trénovací a testovací
[imdsTrain, imdsValidation] = splitEachLabel (imds, 0.7, 'randomize');

%% Vytváření sítě po vrstvách
layers = [
    imageInputLayer([28 28 1]) %vstupní vrstva (šedotónový obrázek o velikosti 28x28 pixelů)
    convolution2dLayer(5,16,'Padding', 'same') % 16 konv. filtrů o velikosti 5
    batchNormalizationLayer % normalizační vrstva
    reluLayer %relu vrstva přidává nelinearitu (vstup menší než nula je převeden na nulu, v ostatních případech je vstup ponechán)
    
    fullyConnectedLayer(10) % 10 - počet neuronů
    softmaxLayer % normalizace
    classificationLayer 
];

%% trénovací možnosti
options = trainingOptions('sgdm',...% typ řešitele
    'Verbose', false,...% bez výstupu do command window
    'Plots', 'training-progress',...% vytvoří graf s průbehem trénování
    'MaxEpoch',5,...%každý obrázek bude použit pro trénování 5x
    'ValidationData', imdsValidation); % validační data

%% 
net = trainNetwork (imdsTrain, layers, options); % samotný trénink
```