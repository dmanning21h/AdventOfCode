print(f"Part 1: {sum([2**(11-i) if sum(arr) > 500 else 0 for i, arr in enumerate([[int(line[i]) for line in open('day3.txt').read().splitlines()] for i in range(len(open('day3.txt').read().splitlines()[0]))])]) * sum([2**(11-i) if sum(arr) < 500 else 0 for i, arr in enumerate([[int(line[i]) for line in open('day3.txt').read().splitlines()] for i in range(len(open('day3.txt').read().splitlines()[0]))])])}")

oxygen = open('day3.txt').read().splitlines()
i = 0
while(len(oxygen) > 1):
    if sum([int(value[i]) for value in oxygen]) >= len(oxygen) / 2:
        oxygen = [value for value in oxygen if value[i] == '1']
    else:
        oxygen = [value for value in oxygen if value[i] == '0']

    i += 1
oxygen = oxygen[0]

co2 = open('day3.txt').read().splitlines()
i = 0
while(len(co2) > 1):
    if sum([int(value[i]) for value in co2]) >= len(co2) / 2:
        co2 = [value for value in co2 if value[i] == '0']
    else:
        co2 = [value for value in co2 if value[i] == '1']

    i += 1
co2 = co2[0]

def binary_to_decimal(binary):
    decimal = 0
    for j in range(len(binary)):
        decimal += int(binary[j]) * (2 ** (11 - j))
    return decimal

print(f"Part 2: {binary_to_decimal(oxygen) * binary_to_decimal(co2)}")