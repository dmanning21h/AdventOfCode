print(f"\nDay 1\nPart 1: {sum([1 for i in range(len([int(line.rstrip()) for line in open('2021/day123/day1.txt')]) - 1) if [int(line.rstrip()) for line in open('2021/day123/day1.txt')][i+1] > [int(line.rstrip()) for line in open('2021/day123/day1.txt')][i]])}\nPart 2: {sum([1 for i in range(len([int(line.rstrip()) for line in open('2021/day123/day1.txt')]) - 3) if sum([int(line.rstrip()) for line in open('2021/day123/day1.txt')][i+1:i+4]) > sum([int(line.rstrip()) for line in open('2021/day123/day1.txt')][i: i+3])])}\n\nDay 2\nPart {(aim := 0) + 1}: {sum([(int(line.rstrip().split()[1]) if line.split()[0] == 'down' else (-1 * int(line.rstrip().split()[1]) if line.split()[0] == 'up' else 0)) for line in open('2021/day123/day2.txt')]) * sum([int(line.rstrip().split()[1]) if line.split()[0] == 'forward' else 0 for line in open('2021/day123/day2.txt')])}\nPart {(depth := 0) + 2}: {sum([int(line.rstrip().split()[1 + 0 * (depth:=(int(line.rstrip().split()[1]) * aim) + depth)]) if line.split()[0] == 'forward' else (0 * (aim := aim + int(line.rstrip().split()[1])) if line.split()[0] == 'down' else (0 * (aim := aim - int(line.rstrip().split()[1])) if line.split()[0] == 'up' else 0)) for line in open('2021/day123/day2.txt')]) * depth}\n\nDay 3\nPart 1: {sum([2**(11-i) if sum(arr) > 500 else 0 for i, arr in enumerate([[int(line[i]) for line in open('2021/day123/day3.txt').read().splitlines()] for i in range(len(open('2021/day123/day3.txt').read().splitlines()[0]))])]) * sum([2**(11-i) if sum(arr) < 500 else 0 for i, arr in enumerate([[int(line[i]) for line in open('2021/day123/day3.txt').read().splitlines()] for i in range(len(open('2021/day123/day3.txt').read().splitlines()[0]))])])}\nPart 2: {str([oxygen := open('2021/day123/day3.txt').read().splitlines()].extend([ oxygen := [[value for value in oxygen if value[i] == '1'] if sum([int(value[i]) for value in oxygen]) >= len(oxygen) / 2 else [value for value in oxygen if value[i] == '0']][0] if len(oxygen) > 1 else oxygen for i in range(12)]) or '')}{str([co2 := open('2021/day123/day3.txt').read().splitlines()].extend([co2 := [[value for value in co2 if value[i] == '0'] if sum([int(value[i]) for value in co2]) >= len(co2) / 2 else [value for value in co2 if value[i] == '1']][0] if len(co2) > 1 else co2 for i in range(12)]) or '')}{int((oxygen)[0], base=2) * int(co2[0], base=2)}\n")