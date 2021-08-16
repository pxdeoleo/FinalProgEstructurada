Imports System

Module Program
    Sub GameOver()
        Console.WriteLine("Se acabo el juego.")
        End
    End Sub

    Function esPalindroma(cadena As String) As Boolean
        If cadena.Length < 2 Then Return True

        If cadena(0) = cadena(cadena.Length - 1) Then
            Return esPalindroma(cadena.Substring(1, cadena.Length - 2))
        End If

        Return False
    End Function

    Function random_name(ByRef names_list As List(Of String)) As String
        Dim name As String
        Dim rnd As New Random()
        Dim rnd_index As Integer = rnd.Next(0, names_list.Count - 1)

        name = names_list(rnd_index)
        names_list.RemoveAt(rnd_index)

        Return name
    End Function

    Sub Main(args As String())
        Dim continuar As Boolean = True

        Console.Title = "The Hollow"

        Console.WriteLine("Mientras nuestros 3 amigos despertaron de un largo sueño, encerrados en una")
        Console.WriteLine("habitación, estaba preguntándose, ¿quiénes eran?, de pronto, uno de ellos encontró")
        Console.WriteLine("un papel dentro del pantalón con un nombre, luego los demás hicieron lo mismo." + Environment.NewLine)

#Region "1. Asignacion de nombres"
        ' Lista de nombres Hombres [0-2] Mujeres [3-4] Objetos [5-9]
        Dim nombres As New List(Of String)({"Kevin", "Alexander", "Jose", "Ana", "Mabel", "Telefono", "Impresora", "Teclado", "Monitor", "Mouse"})
        Dim cont_hombres, cont_mujeres As Integer

        Dim chances_nombre As Integer = 5

        Dim players As New List(Of String)({"", "", ""})

        players(0) = "Kevin"
        players(1) = "Jose"
        players(2) = "Ana"

        'While True
        '    Dim tmp_nombres As New List(Of String)({"Kevin", "Alexander", "Jose", "Ana", "Mabel", "Telefono", "Impresora", "Teclado", "Monitor", "Mouse"})

        '    cont_hombres = 0
        '    cont_mujeres = 0

        '    For i As Integer = 0 To 2 Step 1
        '        players(i) = random_name(tmp_nombres)

        '        If nombres.GetRange(0, 3).Contains(players(i)) Then
        '            cont_hombres += 1
        '        End If

        '        If nombres.GetRange(3, 2).Contains(players(i)) Then
        '            cont_mujeres += 1
        '        End If


        '    Next

        '    chances_nombre -= 1

        '    If cont_hombres = 2 And cont_mujeres = 1 Then
        '        Console.WriteLine("Cantidad correcta")
        '        Console.WriteLine($"Nombres: {players(0)}, {players(1)}, {players(2)}")
        '        'Console.ReadKey()
        '        Exit While
        '    Else
        '        If chances_nombre = 0 Then
        '            Console.WriteLine("THE HOLLOW CANNOT BE INITIALIZED, GAME OVER")
        '            GameOver()
        '        End If
        '    End If

        'End While

        Console.WriteLine($"Los nombres de nuestros héroes son {players(0)}, {players(1)} y {players(2)}" + Environment.NewLine)


#End Region

#Region "2. Palabra palindroma"
        Dim palabra As String
        Dim intentos As Integer = 1

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

        Console.WriteLine($"Luego de que nuestros amigos {players(0)}, {players(1)} y {players(2)} son")
        Console.WriteLine("sacados de la habitación, aparecieron en un camino helado y desconocido. En este")
        Console.WriteLine("camino, encontraron un mapa, con la ubicación secreta de la llave que los llevaría a")
        Console.WriteLine("su casa." + Environment.NewLine)
        Console.WriteLine("El mapa estaba compuesto de 3 partes, las cuales se hacen visible, cada vez que")
        Console.WriteLine("puedan vencer un desafío.")

#Region "Desafio no. 3"
        Dim letra1 As String
        Dim letra2 As String

        While True
            Console.Write("Ingrese la primera letra: ")

            letra1 = Console.ReadLine()
            If IsNumeric(letra1) Then
                Console.WriteLine("El valor ingresado es numerico. Por favor ingrese una letra.")
            Else
                Exit While
            End If
        End While

        While True
            Console.Write("Ingrese la primera letra: ")

            letra2 = Console.ReadLine()
            If IsNumeric(letra2) Then
                Console.WriteLine("El valor ingresado es numerico. Por favor ingrese una letra.")
            Else
                Exit While
            End If

        End While

        Console.WriteLine("Los valores introducidos fueron: {0} & {1}", letra1, letra2)
#End Region
    End Sub
End Module
