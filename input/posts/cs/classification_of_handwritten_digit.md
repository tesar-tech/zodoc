title: Klasifikace ručně psaného čísla
lead: Načíst konvoluční neuronovou síť v onnx formátu. Zmenšit a klasifikovat obrázek
Published: 2018-12-11
Tags: [matlab, MNIST, classification, handwritten, digits]
datazooFiles: [imgs/single_handwritten_digit.png, models/MNIST_99.29.onnx ]
prerequisites: [Matlab,Matlab onnx support add-on]
Authors: tesar-tech
---
Model v onnx formátu byl natrénován na [MNIST](http://yann.lecun.com/exdb/mnist/) datasetu s přesností 99.29 %.
  
``` matlab
mnist_net = importONNXNetwork('MNIST_99.29.onnx','OutputLayerType','classification','ClassNames',{'0','1','2','3','4','5','6','7','8','9'}); %improt sítě

A = rgb2gray(imread('single_handwritten_digit.png'));%Načíst obrázek a převést na šedotón
A_resized = imresize(A,[28 28]);%Zmenšit na [28x28] cožodpovídá vstupní vrstvě neuronové sítě

[label, score] = classify(mnist_net,A_resized,'ExecutionEnvironment','cpu');%(problém s GPU při používání onnx modelu, proto zde využito cpu)
A_withText = insertText(A,[1 1], cellstr("classified as " +  string(label)+newline+ "("+ num2str(max(score)*100,'%0.2f %%)')) ,'FontSize',28); % přidat text s výsledkem kalsifikace
imshow(A_withText)
```