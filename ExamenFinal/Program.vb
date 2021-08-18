Imports System

Module Program
    Sub GameOver()
        'Subrutina. Se encarga de detener el programa
        'Se le llama cada vez que ocurre un Game Over
        Console.WriteLine("Se acabo el juego.")
        End
    End Sub

    Function esPalindroma(cadena As String) As Boolean
        'Funcion que recibe un String, retorna True o False si
        'dicho string es un palindromo o no
        If cadena.Length < 2 Then Return True

        If cadena(0) = cadena(cadena.Length - 1) Then
            Return esPalindroma(cadena.Substring(1, cadena.Length - 2))
        End If

        Return False
    End Function

    Function random_name(ByRef names_list As List(Of String)) As String
        'Funcion. Tomma una lista de strings por referencia. Retorna un string
        'Se encarga de retornar aleatoriamente uno de los strings de la lista.
        'Se utiliza para asignar aleatoriamente los nombres de los jugadores
        Dim name As String
        Dim rnd As New Random()
        Dim rnd_index As Integer = rnd.Next(0, names_list.Count - 1)

        name = names_list(rnd_index)
        names_list.RemoveAt(rnd_index)

        Return name
    End Function

    Function DesvEst(x As Double()) As Double
        'Funcion. Toma un arreglo de doubles. Retorna un double
        'Calcula la desviacion estandar de los numeros dentro del arreglo
        Dim suma, resultado As Double

        If x.Any Then

            For Each item As Double In x
                suma += Math.Pow(item - x.Average, 2)
            Next
            'sum es la suma de todos los datos.
            'function(num) es para interactuar con los datos del arreglo
            'pow es para elevar a una cantidad en este caso 2
            'average es el promedio
            'entonces al numero se le resta el promedio y se eleva al cuadrado
            '
            resultado = Math.Sqrt((suma) / (x.Length - 1))
            'SQRT es para sacar la raiz del resultado de la suma final que calculamos arriba entre el tama;o de nuestro arreglo
            Return resultado
        End If
        Return 0
    End Function

    Sub Main(args As String())
        Dim continuar As Boolean = True

        Console.Title = "The Hollow"

        Console.WriteLine("Mientras nuestros 3 amigos despertaron de un largo sueño, encerrados en una")
        Console.WriteLine("habitación, estaba preguntándose, ¿quiénes eran?, de pronto, uno de ellos encontró")
        Console.WriteLine("un papel dentro del pantalón con un nombre, luego los demás hicieron lo mismo." + Environment.NewLine)

#Region "Accion No. 1"
        ' Lista de nombres. Hombres en indices [0-2] Mujeres indices [3-4] Objetos indices [5-9]
        ' Los hombres se almacenen en una lista, la mujer en una variable string
        Dim nombres As New List(Of String)({"Kevin", "Alexander", "Jose", "Ana", "Mabel", "Telefono", "Impresora", "Teclado", "Monitor", "Mouse"})

        Dim intentos As Integer = 0

        Dim hombres As List(Of String)
        Dim mujer As String = ""

        While True
            'Bucle para asignar los nombres y verificar si son la cantidad correcta
            Dim tmp_nombres As New List(Of String)({"Kevin", "Alexander", "Jose", "Ana", "Mabel", "Telefono", "Impresora", "Teclado", "Monitor", "Mouse"})
            hombres = New List(Of String)
            mujer = ""

            intentos += 1

            For h As Integer = 0 To 2 Step 1
                'Bucle para asignar los nombres aleatoriamente.
                Dim player As String
                player = random_name(tmp_nombres)

                If nombres.GetRange(0, 3).Contains(player) Then
                    hombres.Add(player)
                End If

                If nombres.GetRange(3, 2).Contains(player) Then
                    mujer = player
                End If
                Console.WriteLine($"Intento: {intentos} | Nombre: {player}")
            Next
            Console.WriteLine("--------------")


            If hombres.Count = 2 And Not String.IsNullOrEmpty(mujer) Then
                'Si hay dos hombres y la variable Mujer tiene valor, entonces se rompe
                'el While y se continua el juego
                Exit While
            Else
                If intentos = 5 Then
                    Console.WriteLine("THE HOLLOW CANNOT BE INITIALIZED, GAME OVER")
                    GameOver()
                End If
            End If

        End While

        Console.WriteLine($"Los nombres de nuestros héroes son {hombres(0)}, {mujer} y {hombres(1)}" + Environment.NewLine)
        Console.ReadKey()

#End Region

#Region "Accion 2. Palabra palindroma"
        Dim palabra As String
        intentos = 0

        Console.WriteLine("Dentro de la habitación hay una máquina de escribir, la cual le va a permitir salir de")
        Console.WriteLine("la habitación escribiendo con ella la palabra mágica, la cual debe ser una palabra")
        Console.WriteLine("Palíndroma." + Environment.NewLine)

        'Bucle de intentos
        While True
            Console.Write("Ingrese la palabra magica: ")
            palabra = Console.ReadLine().ToLower()

            If esPalindroma(palabra) Then
                Exit While
            Else
                If intentos = 5 Then
                    Console.WriteLine("THE HOLLOW CANNOT BE INITIALIZED, GAME OVER.")
                    GameOver()
                End If
                Console.WriteLine("Por favor intentelo de nuevo.")
                intentos += 1
            End If

        End While

#End Region

        Console.WriteLine($"Luego de que nuestros amigos {hombres(0)}, {mujer} y {hombres(1)} son")
        Console.WriteLine("sacados de la habitación, aparecieron en un camino helado y desconocido. En este")
        Console.WriteLine("camino, encontraron un mapa, con la ubicación secreta de la llave que los llevaría a")
        Console.WriteLine("su casa." + Environment.NewLine)
        Console.WriteLine("El mapa estaba compuesto de 3 partes, las cuales se hacen visible, cada vez que")
        Console.WriteLine("puedan vencer un desafío." + Environment.NewLine)

#Region "Desafio no. 1"
        Console.WriteLine("Para poder hacer visible la segunda parte del mapa, deben poder llegar a la cima de")
        Console.WriteLine("una montaña, pero, desde el punto en que se encuentran, no saben, a que distancia")
        Console.WriteLine("esta la montaña ni la altura que deben escalar, esto es posible conocerlo si se resuelve")
        Console.WriteLine("el siguiente problema:" + Environment.NewLine)

        Dim x(1) As Integer
        Dim suma, sumaCuadrado, promedio, total As Integer
        Dim tiempo, velocidad As Integer
        'Dim A, B, C, D, E As Integer
        Dim i As Integer = 0
        Dim numbers(4) As Double

        While x.Length > i
            Console.WriteLine("Introduzca el {0}er numero", i + 1)
            Try
                x(i) = Console.ReadLine()
                Console.WriteLine()
                i += 1
            Catch ex As Exception
                Console.WriteLine("DEBE INTRODUCIR UN NUMERO")
                Console.WriteLine()
            End Try

        End While

        Select Case x.Any
            Case x(0) > x(1)
                Console.WriteLine("MAYOR")
                suma = x(0) + x(1)

                If (suma Mod x(0)) = 0 Or (suma Mod x(1)) = 0 Then
                    Console.WriteLine("La suma tiene una division exacta con alguno de los numeros")  'NO SE QUE HACER AQUI SI NO SE PUEDE
                    i = 0
                    While numbers.Length > i
                        Console.WriteLine("Introduzca el {0}er numero", i + 1)
                        Try
                            numbers(i) = Console.ReadLine()
                            Console.WriteLine()
                            i += 1
                        Catch ex As Exception
                            Console.WriteLine("DEBE INTRODUCIR EL TIEMPO")
                            Console.WriteLine()
                        End Try
                    End While

                    '(C > ((A+B+D+E)/4)) OR (E = ((A + B) * D))
                    If (numbers(2) > ((numbers(0) + numbers(1) + numbers(3) + numbers(4)) / 4)) Or (numbers(4) = ((numbers(0) + numbers(1)) * numbers(3))) Then
                        Console.WriteLine("Es la distancia para recorrer para llegar a la cima de la montaña: {0}", Math.Round(DesvEst(numbers) * 10, 2))
                    Else
                        Console.WriteLine("OurFriends are already frozen, this is a GAMEOVER")
                        GameOver()
                    End If

                Else
                    sumaCuadrado = x(0) ^ 2 + x(1) ^ 2
                    promedio = suma / 2
                    total = suma + sumaCuadrado + promedio

                    If total > 100 Then
                        While True
                            Console.WriteLine("Introduzca la velocidad en KM/H ")
                            Try
                                velocidad = Console.ReadLine()
                                Console.WriteLine()
                                Exit While
                            Catch ex As Exception
                                Console.WriteLine("DEBE INTRODUCIR LA VELOCIDAD")
                                Console.WriteLine()
                                Continue While
                            End Try
                        End While

                        While True
                            Console.WriteLine("Introduzca el tiempo en Min")
                            Try
                                tiempo = Console.ReadLine()
                                Console.WriteLine()
                                Exit While
                            Catch ex As Exception
                                Console.WriteLine("DEBE INTRODUCIR EL TIEMPO")
                                Console.WriteLine()
                                Continue While
                            End Try
                        End While

                        Console.WriteLine("La distancia es {0} KM", Math.Round((velocidad * (tiempo / 60)), 2))

                    ElseIf total < 100 Then
                        Console.WriteLine("GAME OVER")
                        GameOver()
                    End If

                End If

            Case x(1) > x(0)
                Console.WriteLine("MENOR")
                i = 0
                While numbers.Length > i
                    Console.WriteLine("Introduzca el numero {0}", i + 1)
                    Try
                        numbers(i) = Console.ReadLine()
                        Console.WriteLine()
                        i += 1
                    Catch ex As Exception
                        Console.WriteLine("DEBE INTRODUCIR EL TIEMPO")
                        Console.WriteLine()
                    End Try
                End While

                '(C > ((A+B+D+E)/4)) OR (E = ((A + B) * D))
                If (numbers(2) > ((numbers(0) + numbers(1) + numbers(3) + numbers(4)) / 4)) Or (numbers(4) = ((numbers(0) + numbers(1)) * numbers(3))) Then
                    Console.WriteLine("Es la distancia para recorrer para llegar a la cima de la montaña: {0}", Math.Round(DesvEst(numbers) * 10, 2))
                Else
                    Console.WriteLine("OurFriends are already frozen, this Is a GAMEOVER�")
                    GameOver()
                End If
            Case Else
                Console.WriteLine("AMBOS SON IGUALES, GAME OVER")
                GameOver()
        End Select
#End Region

#Region "Desafio no. 2"
        Dim valorA, valorB, valorC As Integer

        Console.WriteLine("Deben enfrentarse al gran dragon ZU (un enorme dragón, a")
        Console.WriteLine("veces considerado el pájaro de la tormenta, en la ")
        Console.WriteLine("mitología  de  la  antigua  Mesopotamia.  Nació  en  la montaña Hehe")
        Console.WriteLine("Para  poder  vencer  al  dragón,  deben  poder  atravesarlo ")
        Console.WriteLine("con una lanza, para poder hacer esto, deben conocer al ")
        Console.WriteLine("gran ARES, el Dios de la Guerra injusta. Les va a proporcionar la lanza si resuelven este acetijo." + Environment.NewLine)

        Console.WriteLine("Cada  digito  ha  sido  reemplazado  por  una  letra.  Cada  letra  representa  el  mismo")
        Console.WriteLine("número allí donde aparece. Los dígitos son 0, 4 y 8 (A, B y C respectivamente). " + Environment.NewLine)

        Console.WriteLine("
        A   C	A
    -   C   C	C
      -------------
        C   B	C" + Environment.NewLine)

        Console.WriteLine("Introduzcan los valores de A,B,C.")
        While True
            'Mientras el valor no sea numerico, seguira pidiendo el numero
            Console.WriteLine("Ingrese el valor de A: ")
            If Integer.TryParse(Console.ReadLine, valorA) Then
                Exit While
            Else
                Console.WriteLine("Por favor ingrese un valor valido.")
            End If
        End While

        While True
            Console.WriteLine("Ingrese el valor de B: ")
            If Integer.TryParse(Console.ReadLine, valorB) Then
                Exit While
            Else
                Console.WriteLine("Por favor ingrese un valor valido.")
            End If
        End While

        While True
            Console.WriteLine("Ingrese el valor de C: ")
            If Integer.TryParse(Console.ReadLine, valorC) Then
                Exit While
            Else
                Console.WriteLine("Por favor ingrese un valor valido.")
            End If
        End While

        If valorA = 8 And valorB = 0 And valorC = 4 Then
            Console.WriteLine("Resolvieron el acertijo, Ares les otorga la lanza. Pero solo uno de los tres podra pelear contra el dragon.")
            Console.WriteLine("Quien sera el valiente que peleara contra Zu?")
        Else
            Console.WriteLine("THIS IS AND GAME POINT, THE ISSUE CANNOT BE SOLVED")
            GameOver()
        End If
#End Region

#Region "Desafio no. 3"
        Dim letra1, letra2 As Char
        Dim letra1Bin, letra2Bin As String
        Dim luchador As String

        Console.WriteLine("Ingrese dos letras que pertenezcan al alfabeto." + Environment.NewLine)

        While True
            Console.Write("Ingrese la primera letra: ")

            'Se toma la tecla que el usuario presione y se obtiene su Char
            letra1 = Console.ReadKey.KeyChar
            Console.WriteLine()

            'Si el Char es una letra, se rompe el bucle y se continua con la proxima
            'Sino, se alerta al usuario y se solicita de nuevo
            If Char.IsLetter(letra1) Then
                Exit While
            Else
                Console.WriteLine("Por favor ingrese una letra que pertenezca al alfabeto.")
            End If
        End While

        While True
            Console.Write("Ingrese la segunda letra: ")

            letra2 = Console.ReadKey.KeyChar
            Console.WriteLine()

            If Char.IsLetter(letra1) Then
                Exit While
            Else
                Console.WriteLine("Por favor ingrese una letra que pertenezca al alfabeto.")
            End If
        End While

        ' Se convierten la letra a Byte (Su representacion ASCII) y posteriormente a String

        letra1Bin = Convert.ToByte(letra1).ToString
        letra2Bin = Convert.ToByte(letra2).ToString

        'Se compara el primer digito (primer caracter del string) con el ultimo
        'Si son iguales, luchador es la mujer
        'Si no, luchador es el hombre con el apellido mas largo
        If letra1Bin(0) = letra2Bin(letra2Bin.Length - 1) Then
            luchador = mujer
        Else
            If hombres(0).Length > hombres(1).Length Then
                luchador = hombres(0)
            Else
                luchador = hombres(1)
            End If
        End If

        Console.WriteLine($"{luchador} sérá quien luche contra el dragón.")
        Console.WriteLine("Para vencer al dragón con la lanza, el luchador debe encontrar su punto débil.")

        Dim x1, x2, y1, y2 As Integer
        Dim Distancia As Integer

        While True
            Console.WriteLine($"Ingrese la coordenada X de {luchador}: ")

            'Se verifica que el dato que ingrese el usuario sea un numero
            'Y que este entre 500 y 1000
            If Integer.TryParse(Console.ReadLine, x1) Then
                If x1 < 500 Or x1 > 1000 Then
                    Console.WriteLine("El numero debe estar entre 500 y 1000. Intentelo de nuevo")
                    Continue While
                End If
            Else
                Console.WriteLine("Por favor ingrese un numero valido")
            End If
        End While

        While True
            Console.WriteLine($"Ingrese la coordenada Y de {luchador}: ")

            If Integer.TryParse(Console.ReadLine, x2) Then
                'Ademas de las validaciones anteriores, se comprueba que el numero que se ingrese
                'no sea igual a los anteriores
                If x1 = x2 Then
                    Console.WriteLine("Asegurese de que todos los numeros sean diferentes.")
                    Continue While
                End If

                If x1 < 500 Or x1 > 1000 Then
                    Console.WriteLine("El numero debe estar entre 500 y 1000. Intentelo de nuevo")
                    Continue While
                End If
            End If
        End While

        While True
            Console.WriteLine("Ingrese la coordenada X del dragon: ")

            If Integer.TryParse(Console.ReadLine, y1) Then
                If y1 = x1 Or y1 = x2 Then
                    Console.WriteLine("Asegurese de que todos los numeros sean diferentes.")
                    Continue While
                End If

                If x1 < 500 Or x1 > 1000 Then
                    Console.WriteLine("El numero debe estar entre 500 y 1000. Intentelo de nuevo")
                    Continue While
                End If
            End If
        End While

        While True
            Console.WriteLine("Ingrese la coordenada Y del dragon: ")

            If Integer.TryParse(Console.ReadLine, y2) Then
                If y2 = y1 Or y2 = x1 Or y2 = x2 Then
                    Console.WriteLine("Asegurese de que todos los numeros sean diferentes.")
                    Continue While
                End If

                If x1 < 500 Or x1 > 1000 Then
                    Console.WriteLine("El numero debe estar entre 500 y 1000. Intentelo de nuevo")
                    Continue While
                End If
            End If

        End While

        Distancia = Math.Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2)

        Console.WriteLine($"El dragón está a {Distancia} metros." + Environment.NewLine)
        Console.WriteLine($"{luchador} arroja la lanza con todas sus fuerzas, impactando al dragón, que cae herido de gravedad." + Environment.NewLine)
        Console.WriteLine("Hay un monstruo con mucho más poder que él, y es mejor no enfrentarlo, para hacer")
        Console.WriteLine("esto y poder subir la montaña, deben pronunciar su nombre tres veces, uno cada")
        Console.WriteLine("personaje.")


#End Region

#Region "Accion 3"

        'Se crean dos arreglos bidimensionales. Contienen una letra y un numero. El numero representa el orden
        'en el que van las letras de la palabra DEMOGORGON

        'desorden representa la palabra D M O G O R G O N

        Dim desorden As String(,) = New String(9, 1) {{"E", "1"}, {"D", "0"}, {"M", "2"}, {"O", "3"}, {"G", "4"}, {"O", "8"}, {"R", "6"}, {"G", "7"}, {"O", "5"}, {"N", "9"}}

        While True
            'Debido a que Length retorna todos los elementos del arreglo (que en total son 20), se divide en 2
            'para acceder solo a los numeros y no a las letras
            For j As Integer = 0 To desorden.Length / 2 - 2 Step 1
                'Se compara si el numero de la izquierda es mayor al de la derecha
                'Si lo es, intercambian lugares
                If Integer.Parse(desorden(j, 1)) > Integer.Parse(desorden(j + 1, 1)) Then
                    Dim tmpArray As String() = New String(1) {}

                    'Se almacena uno de las duplas temporalmente
                    'en un arreglo de dos posiciones
                    tmpArray(0) = desorden(j, 0)
                    tmpArray(1) = desorden(j, 1)

                    desorden(j, 0) = desorden(j + 1, 0)
                    desorden(j, 1) = desorden(j + 1, 1)

                    desorden(j + 1, 0) = tmpArray(0)
                    desorden(j + 1, 1) = tmpArray(1)
                End If
            Next

            Dim palabra_concat As String = ""

            'Se concatenan las letras del arreglo en un string, letra por letra
            For l As Integer = 0 To desorden.Length / 2 - 1 Step 1
                palabra_concat += desorden(l, 0)
            Next

            Console.WriteLine(palabra_concat + Environment.NewLine)

            If palabra_concat = "DEMOGORGON" Then
                Console.WriteLine("DEMOGORGON!")
                Console.WriteLine("DEMOGORGON!!")
                Console.WriteLine("DEMOGORGON!!!")
                Exit While
            End If

        End While
#End Region

        Console.WriteLine($"Gritaron {hombres(0)}, {mujer} y {hombres(1)}.")
        Console.WriteLine("Inmediatamente son teletransportados a la cima de la montaña.")
        Console.WriteLine("Habiendo cumplido los 3 desafíos, la llave es")
        Console.WriteLine("entregada a ellos por el venger, que admitiendo")
        Console.WriteLine("su derrota les permite continuar su camino hacia")
        Console.WriteLine("su hogar entregándoles la llave del gran portón." + Environment.NewLine)

        Console.WriteLine("Fin del juego. Presione cualquier tecla para concluir.")
        Console.ReadKey()
    End Sub
End Module
