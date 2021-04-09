#!/bin/bash
echo "Hello, World!"
ARQUIVOS=`dir`
echo "Nome dos arquivos desse diretório: "
for ARQUIVO in $ARQUIVOS
do
	echo $ARQUIVO
done
chmod +x script.sh