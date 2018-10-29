title: Test základních znalostí 2018a
--- 
# Zatmění čtvercového měsíce
 ``` matlab
	  A=imread('kytka256.jpg');
    vektor=uint8([0:2:255 255:-2:0]);
    plocha = repmat(vektor,256,1);
    plocha(128-20:128+20,128-20:128+20)=100;
    imshow(plocha);
 ```
# Dva bináry
 ``` matlab
    A_seda=rgb2gray(A);
    bila = find(A_seda>128);
    cerna = find(A_seda<128);
    A_seda(bila)=255;
    A_seda(cerna)=0;

    A_seda2=rgb2gray(A);
    A_seda2(bila) = 0;
    A_seda2(cerna)=255;
    subplot(2,1,1); imshow(A_seda);
    subplot(2,1,2) ;imshow(A_seda2);
 ```
# Čtvrtinky
 ``` matlab
    A_ctvrt1=A(1:128,1:128,:);
    A_ctvrt2=A(128:256,1:128,:);
    A_ctvrt3=A(1:128,128:256,:);
    A_ctvrt4=A(128:256,128:256,:);
    subplot(2,2,1);imshow(A_ctvrt1)
    subplot(2,2,2);imshow(A_ctvrt3)
    subplot(2,2,3);imshow(A_ctvrt2)
    subplot(2,2,4);imshow(A_ctvrt4)
 ```
# Čtvrtinky - libovolná velikost obrazu
 ``` matlab
    velikost=size(A);
    polovina_delka=round(velikost(1)/2);
    polovina_sirka=round(velikost(2)/2);
    A_ctvrt1=A(1:polovina_delka,1:polovina_sirka,:);
    A_ctvrt2=A(polovina_delka:end,1:polovina_sirka,:);
    A_ctvrt3=A(1:polovina_delka,polovina_sirka:end,:);
    A_ctvrt4=A(polovina_delka:end,polovina_sirka:end,:);
    subplot(2,2,1);imshow(A_ctvrt1)
    subplot(2,2,3);imshow(A_ctvrt2)
    subplot(2,2,2);imshow(A_ctvrt3)
    subplot(2,2,4);imshow(A_ctvrt4)
 ```

