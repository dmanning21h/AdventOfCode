filename = '2021/day4/day4.txt'

numbers_called = [int(i) for i in open(filename).readline().rstrip().split(',')]

def get_boards():
    boards = [[]]
    i = 0
    with open(filename) as f:
        next(f)
        next(f)
        for line in f:
            row = line.split()
            if row == []:
                boards.append([])
                i += 1
            else:
                boards[i].append({int(n): False for n in row})
    return boards

def main():
    part_one()
    part_two()
    

def part_one():
    boards = get_boards()
    for number_called in numbers_called:
        for board in boards:
            if does_board_contain_number(board, number_called):
                if did_board_win(board):
                    print(f"\nPart 1: {number_called * sum_of_unmarked(board)}")
                    return

def part_two():
    boards = get_boards()
    for number_called in numbers_called:
        for board in boards:
            if does_board_contain_number(board, number_called):
                if did_board_win(board):
                    if len(boards) == 1:
                        print(f"Part 2: {number_called * sum_of_unmarked(board)}")
                        return
                    else:
                        boards.remove(board)

def print_board(board):
    for row in board:
        print(row)
    print()


def does_board_contain_number(board, number_called):
    contains = False
    for row in board:
        if number_called in row.keys():
            row[number_called] = True
            contains = True
    return contains
            
def did_board_win(board):
    row_win = check_rows(board)
    if row_win:
        return True
    column_win = check_columns(board)
    if column_win:
        return True
    return False

def check_rows(board):
    for row in board:
        if all(row.values()):
            return True
    return False

def check_columns(board):
    columns = [{} for _ in range(5)]
    for i in range(5):
        for row in board:
            key = get_nth_key(row, i)
            columns[i][key] = row[key]
    for column in columns:
        if all(column.values()):
            return True
    return False

def get_nth_key(dictionary, n=0):
    for i, key in enumerate(dictionary.keys()):
        if i == n:
            return key

def sum_of_unmarked(board):
    total = 0
    for row in board:
        for number, was_called in row.items():
            if not was_called:
                total += number
    return total


if __name__ == '__main__':
    main()