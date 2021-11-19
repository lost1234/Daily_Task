#!/usr/bin/env python3
# _*_ coding=utf-8 _*_
import csv
from typing import Type
from urllib.request import urlopen
from bs4 import BeautifulSoup
from urllib.request import HTTPError
try:
  html = urlopen("https://docs.microsoft.com/en-us/azure/cognitive-services/Translator/language-support")
except HTTPError as e:
  print("not found")
bsObj = BeautifulSoup(html,"html.parser")
print(type(bsObj))
tables = bsObj.findAll("table")
if tables is None:
  print("no table");
  exit(1)
i = 1
for table in tables:
  fileName = "table%s.csv" % i
  rows = table.findAll("tr")
  csvFile = open(fileName,'wt',newline='',encoding='utf-16')
  writer = csv.writer(csvFile)
  try:
    for row in rows:
      csvRow = []
      for cell in row.findAll(['td','th']):

        csvRow.append(cell.get_text())
        # print(type(csvRow[0])) 
      writer.writerow(csvRow)
  finally:
    csvFile.close()
  i += 1