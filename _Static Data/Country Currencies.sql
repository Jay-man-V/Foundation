/*
select id, '-- ' + EnglishName from core.Country order by EnglishName
select * from core.Country
*/

BEGIN TRAN

update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'؋', CurrencyISOCode = 'AFN', CurrencyName = 'Afghani', CurrencyNumbertoBasic = 100 where id = 200 -- AFGHANISTAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'L', CurrencyISOCode = 'ALL', CurrencyName = 'Lek', CurrencyNumbertoBasic = 100 where id = 184 -- ALBANIA;
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'د.ج', CurrencyISOCode = 'DZD', CurrencyName = 'Dinar', CurrencyNumbertoBasic = 100 where id = 8 -- ALGERIA;

update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 213	-- AMERICAN SAMOA

update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'€', CurrencyISOCode = 'EUR', CurrencyName = 'Euro', CurrencyNumbertoBasic = 100 where id = 167	-- ANDORRA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Kz', CurrencyISOCode = 'AOA', CurrencyName = 'Kwanza', CurrencyNumbertoBasic = 100 where id = 53	-- ANGOLA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'XCD', CurrencyName = 'Eastern Caribbean dollar', CurrencyNumbertoBasic = 100 where id = 6	-- ANGUILLA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'XCD', CurrencyName = 'Eastern Caribbean dollar', CurrencyNumbertoBasic = 100 where id = 125	-- ANTIGUA AND BARBUDA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'ARS', CurrencyName = 'Peso', CurrencyNumbertoBasic = 100 where id = 146	-- ARGENTINA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'֏', CurrencyISOCode = 'AMD', CurrencyName = 'Dram', CurrencyNumbertoBasic = 100 where id = 15	-- ARMENIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'ƒ', CurrencyISOCode = 'AWG', CurrencyName = 'Florin', CurrencyNumbertoBasic = 100 where id = 179	-- ARUBA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'AUD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 219	-- AUSTRALIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'€', CurrencyISOCode = 'EUR', CurrencyName = 'Euro', CurrencyNumbertoBasic = 100 where id = 239	-- AUSTRIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'₼', CurrencyISOCode = 'AZN', CurrencyName = 'Manat', CurrencyNumbertoBasic = 100 where id = 130	-- AZERBAIJAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'BSD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 100	-- BAHAMAS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'.د.ب', CurrencyISOCode = 'BHD', CurrencyName = 'Dinar', CurrencyNumbertoBasic = 1000 where id = 94	-- BAHRAIN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'৳', CurrencyISOCode = 'BDT', CurrencyName = 'Taka', CurrencyNumbertoBasic = 100 where id = 22	-- BANGLADESH
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'BBD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 86	-- BARBADOS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Br', CurrencyISOCode = 'BYN', CurrencyName = 'Ruble', CurrencyNumbertoBasic = 100 where id = 44	-- BELARUS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'€', CurrencyISOCode = 'EUR', CurrencyName = 'Euro', CurrencyNumbertoBasic = 100 where id = 155	-- BELGIUM
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'BZD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 30	-- BELIZE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'XOF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 89	-- BENIN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'BMD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 42	-- BERMUDA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Nu.', CurrencyISOCode = 'BTN', CurrencyName = 'Ngultrum', CurrencyNumbertoBasic = 100 where id = 128	-- BHUTAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Bs.', CurrencyISOCode = 'BOB', CurrencyName = 'Boliviano', CurrencyNumbertoBasic = 100 where id = 76	-- BOLIVIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Km', CurrencyISOCode = 'BAM', CurrencyName = 'Mark', CurrencyNumbertoBasic = 100 where id = 52	-- BOSNIA AND HERZEGOVINA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'P', CurrencyISOCode = 'BWP', CurrencyName = 'Pula', CurrencyNumbertoBasic = 100 where id = 1	-- BOTSWANA

update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 47	-- BOUVET ISLAND

update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'R$', CurrencyISOCode = 'BRL', CurrencyName = 'Real', CurrencyNumbertoBasic = 100 where id = 28	-- BRAZIL
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'USD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 193	-- BRITISH INDIAN OCEAN TERRITORY
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'BND', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 171	-- BRUNEI
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'лв.', CurrencyISOCode = 'BGN', CurrencyName = 'Lev', CurrencyNumbertoBasic = 100 where id = 63	-- BULGARIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'XOF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 178	-- BURKINA - Burkina Faso
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Ks.', CurrencyISOCode = 'MMK', CurrencyName = 'Kyat', CurrencyNumbertoBasic = 100 where id = 85	-- BURMA - Myanmar
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'BIF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 25	-- BURUNDI
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'៛', CurrencyISOCode = 'KHR', CurrencyName = 'Riel', CurrencyNumbertoBasic = 100 where id = 104	-- CAMBODIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'XOF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 122	-- CAMEROON
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N''$, CurrencyISOCode = 'CAD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 79	-- CANADA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Esc', CurrencyISOCode = 'CVE', CurrencyName = 'Escudo', CurrencyNumbertoBasic = 100 where id = 11	-- CAPE VERDE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'KYD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 87	-- CAYMAN ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'XAF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 197	-- CENTRAL AFRICAN REPUBLIC
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'XAF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 33	-- CHAD
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'CLP', CurrencyName = 'Peso', CurrencyNumbertoBasic = 100 where id = 39	-- CHILE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'¥', CurrencyISOCode = 'CNY', CurrencyName = 'Yuan', CurrencyNumbertoBasic = 100 where id = 185	-- CHINA

update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 191	-- CHRISTMAS ISLAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 38	-- COCOS (KEELING) ISLANDS

update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'COP', CurrencyName = 'Peso', CurrencyNumbertoBasic = 100 where id = 148	-- COLOMBIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'KMF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 236	-- COMOROS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'CDF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 113	-- CONGO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'CKD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 220	-- COOK ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'₡', CurrencyISOCode = 'CRC', CurrencyName = 'Colón', CurrencyNumbertoBasic = 100 where id = 211	-- COSTA RICA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Kn', CurrencyISOCode = 'HRK', CurrencyName = 'Kuna', CurrencyNumbertoBasic = 100 where id = 153	-- CROATIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'CUP', CurrencyName = 'Peso', CurrencyNumbertoBasic = 100 where id = 199	-- CUBA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'€', CurrencyISOCode = 'EUR', CurrencyName = 'Euro', CurrencyNumbertoBasic = 100 where id = 132	-- CYPRUS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Kč', CurrencyISOCode = 'CZK', CurrencyName = 'Koruna', CurrencyNumbertoBasic = 100 where id = 207	-- CZECH REPUBLIC
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Kr', CurrencyISOCode = 'DKK', CurrencyName = 'Krone', CurrencyNumbertoBasic = 100 where id = 43	-- DENMARK
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'DJF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 172	-- DJIBOUTI
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'XCD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 137	-- DOMINICA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'RD$', CurrencyISOCode = 'DOP', CurrencyName = 'Peso', CurrencyNumbertoBasic = 100 where id = 121	-- DOMINICAN REPUBLIC
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'USD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 1 where id = 126	-- EAST TIMOR
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'USD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 3	-- ECUADOR
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'£', CurrencyISOCode = 'EGP', CurrencyName = 'Pound', CurrencyNumbertoBasic = 100 where id = 180	-- EGYPT
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'USD', CurrencyName = 'USD', CurrencyNumbertoBasic = 100 where id = 234	-- EL SALVADOR
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'£', CurrencyISOCode = 'GBP', CurrencyName = 'Pound', CurrencyNumbertoBasic = 100 where id = 245	-- England
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Fr', CurrencyISOCode = 'XAF', CurrencyName = 'Franc', CurrencyNumbertoBasic = 100 where id = 151	-- EQUATORIAL GUINEA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Nfk', CurrencyISOCode = 'ERN', CurrencyName = 'Nafka', CurrencyNumbertoBasic = 100 where id = 145	-- ERITREA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'€', CurrencyISOCode = 'EUR', CurrencyName = 'Euro', CurrencyNumbertoBasic = 100 where id = 97	-- ESTONIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Br', CurrencyISOCode = 'ETB', CurrencyName = 'Birr', CurrencyNumbertoBasic = 100 where id = 67	-- ETHIOPIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'£', CurrencyISOCode = 'FKP', CurrencyName = 'Pound', CurrencyNumbertoBasic = 100 where id = 192	-- FALKLAND ISLANDS (MALVINAS)
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'Kr', CurrencyISOCode = 'FOK', CurrencyName = 'króna', CurrencyNumbertoBasic = 100 where id = 17	-- FAROE ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 204	-- FIJI
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 235	-- FINLAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 101	-- FRANCE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 84	-- FRENCH GUIANA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 117	-- FRENCH POLYNESIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 61	-- FRENCH SOUTHERN TERRITORIES
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 140	-- GABON
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 91	-- GAMBIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 212	-- GEORGIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 221	-- GERMANY
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 187	-- GHANA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 175	-- GIBRALTAR
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 62	-- GREECE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 224	-- GREENLAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 45	-- GRENADA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 111	-- GUADELOUPE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 165	-- GUAM
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 2	-- GUATEMALA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 41	-- GUINEA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 135	-- GUINEA-BISSAU
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 181	-- GUYANA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 93	-- HAITI
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 99	-- HEARD ISLAND AND MCDONALD ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 95	-- HONDURAS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 36	-- HONG KONG
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 152	-- HUNGARY
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 225	-- ICELAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 92	-- INDIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 123	-- INDONESIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 82	-- IRAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 1000 where id = 90	-- IRAQ
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 51	-- IRELAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 96	-- ISRAEL
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 50	-- ITALY
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 110	-- IVORY COAST
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 194	-- JAMAICA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 60	-- JAPAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 109	-- JORDAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 241	-- KAZAKHSTAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 98	-- KENYA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 240	-- KIRIBATI
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 72	-- Korea (North)
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 166	-- Korea (South)
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 158	-- Kosovo
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 59	-- KUWAIT
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 78	-- KYRGYZSTAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 88	-- Laos
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 173	-- LATVIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 102	-- LEBANON
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 40	-- LESOTHO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 208	-- LIBERIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 1000 where id = 195	-- Libya
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 160	-- LIECHTENSTEIN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 108	-- LITHUANIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 186	-- LUXEMBOURG
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 231	-- MACAU
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 176	-- MACEDONIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 35	-- MADAGASCAR
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 48	-- MALAWI
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 139	-- MALAYSIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 54	-- MALDIVES
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 13	-- MALI
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 34	-- MALTA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 68	-- MARSHALL ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 64	-- MARTINIQUE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 12	-- MAURITANIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 228	-- MAURITIUS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 229	-- MAYOTTE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 106	-- MEXICO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 77	-- Micronesia
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 80	-- MOLDOVA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 162	-- MONACO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 232	-- MONGOLIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 131	-- Montenegro
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 66	-- MONTSERRAT
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 5	-- MOROCCO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 233	-- MOZAMBIQUE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 69	-- MYANMAR
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 58	-- NAMIBIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 29	-- Nauru
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 56	-- NEPAL
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 183	-- NETHERLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 226	-- NETHERLANDS ANTILLES
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 46	-- NEW CALEDONIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 182	-- NEW ZEALAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 83	-- NICARAGUA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 105	-- NIGER
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 120	-- NIGERIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 20	-- NIUE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 210	-- NORFOLK ISLAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 244	-- Northern Ireland
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 163	-- NORTHERN MARIANA ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 189	-- NORWAY
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 1000 where id = 116	-- OMAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 164	-- PAKISTAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 190	-- PALAU
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 223	-- PANAMA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 159	-- PAPUA NEW GUINEA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 143	-- PARAGUAY
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 4	-- PERU
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 21	-- PHILIPPINES
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 124	-- PITCAIRN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 238	-- POLAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 188	-- PORTUGAL
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 65	-- PUERTO RICO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 19	-- QATAR
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 138	-- Reunion Island
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 147	-- ROMANIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 118	-- Russia
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 227	-- RWANDA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 202	-- SAINT HELENA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 205	-- SAINT KITTS AND NEVIS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 156	-- SAINT LUCIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 141	-- SAINT PIERRE AND MIQUELON
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 142	-- SAMOA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 177	-- SAN MARINO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 23	-- SAO TOME AND PRINCIPE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 216	-- SAUDI ARABIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 242	-- Scotland
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 49	-- SENEGAL
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 55	-- Serbia
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 215	-- SEYCHELLES
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 119	-- SIERRA LEONE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 75	-- SINGAPORE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 37	-- SLOVAKIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 114	-- SLOVENIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 103	-- SOLOMON ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 230	-- SOMALIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 9	-- SOUTH AFRICA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 217	-- SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 71	-- SPAIN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 115	-- SRI LANKA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 127	-- St Vincent
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 134	-- SUDAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 112	-- SURINAME
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 174	-- SVALBARD AND JAN MAYEN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 14	-- SWAZILAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 198	-- SWEDEN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 169	-- SWITZERLAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 81	-- SYRIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 70	-- TAIWAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 32	-- TAJIKISTAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 129	-- TANZANIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 214	-- THAILAND
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 150	-- THE DEMOCRATIC REPUBLIC OF THE CONGO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 154	-- TOGO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 196	-- TOKELAU
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 201	-- TONGA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 209	-- TRINIDAD AND TOBAGO
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 222	-- TUNISIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 107	-- TURKEY
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 157	-- TURKMENISTAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 237	-- TURKS AND CAICOS ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 168	-- TUVALU
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 1 where id = 10	-- UGANDA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 170	-- UKRAINE
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 27	-- UNITED ARAB EMIRATES
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 133	-- UNITED KINGDOM
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 18	-- UNITED STATES
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 161	-- UNITED STATES MINOR OUTLYING ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 74	-- URUGUAY
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 206	-- UZBEKISTAN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 144	-- VANUATU
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 203	-- VENEZUELA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 7	-- VIETNAM
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'$', CurrencyISOCode = 'USD', CurrencyName = 'Dollar', CurrencyNumbertoBasic = 100 where id = 57	-- VIRGIN ISLANDS, BRITISH - BRITISH VIRGIN ISLANDS
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 218	-- VIRGIN ISLANDS, U.S.
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 243	-- Wales
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 136	-- WALLIS AND FUTUNA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 73	-- WESTERN SARARA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 31	-- YEMEN
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 149	-- YUGOSLAVIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 100 where id = 16	-- ZAMBIA
update core.country set PrefixCurrencysymbol = 1, CurrencySymbol = N'', CurrencyISOCode = '', CurrencyName = '', CurrencyNumbertoBasic = 1 where id = 26	-- ZIMBABWE
-- rollback
