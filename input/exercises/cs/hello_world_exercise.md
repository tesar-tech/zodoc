title: Zkušební cvičení a popis
order: 0
---
# Úvod
Cvičení je v tomto kontextu myšleno jako procvičování. Celá sekce cvičení (Exercise) slouží k archivaci proběhnuvších testů a úloh k procvičení. 

# Struktura 
``` sql
exercises
├───cs
│       hello_world_exercise.md (aktuální soubor)                   
│       index.cshtml
│
├───en
│       hello_world_exercise.md
│       index.cshtml
│
├───media
│       hello_world_exercise_1.png (obrázek využitý v tomuto souboru)
│
├───solutions
│       (test_case)solution_without_assignment.md
│       hello_world_exercise.md (řešení k tomuto cvičení)
│
└───sources
    └───hello_world_exercise (zdroje k tomuto cvičení)
        │   someMatlabFunction.m
        │   someMatlabScript.m
        │
        └───folderWithImages 
                image01.png
                image02.png
```
Automaticky se generuje několik věci: 
- Odkaz na dokument v případě, že je dostupný v jiném jazyce.
- Odkaz na řešení, v případě že je dostupné (bez jazykových mutací, počítá se s kódem v angličtině).
- Odkaz na složku s dodatečnými soubory (pouze v případě, že je dostupná).

# Jak to funguje 
Soubory všech jazykových mutací se párují podle stejného názvu. Například tento soubor má ve všech mutacích název `hello_world_exercise.md`. Stejný název má i řešení ve složce `solutions` a také složka, se soubory ke cvičení ve složce `sources`. Materiály nejdou dostupné na stránkách, pouze jejich odkaz směřující na GitHub nebo nástroj [DownGit](https://minhaskamal.github.io/DownGit/#/home), který složku z githubu stáhne.

Obrázky se sdílí pro všechny jazykové mutace ve složce `media` (zabrání se tak duplicitám). Je vhodné pojmenovávat obrázky dle souboru. Tedy následující obrázek má název `hello_world_exercise_1.png`. 

![](../media/hello_world_exercise_1.png)

# Jak přidat cvičení
Nejjednodušší způsob pro jednu jazykovou mutaci je jeden soubor s výstižným názvem ve složce dané jazykové mutace. To je vše, co je třeba. Není nutné definovat žádná metadata. Důležité je umístění markdown souboru do správné složky.

Pro složitější scénáře (přidání jazykových mutací, materiálů, řešení) následujte tento ukázkový soubor. 



