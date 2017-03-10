<?php
class Lis {
    public function run($arr) {
        // Check input.
        if (!isset($arr) || !is_array($arr) || count($arr) === 0) {
            throw new Exception('Unacceptable input.');
        }
        // Maintain element order, but assign new keys to ensure they're correct.
        $this->sequence = array_values($arr);
        // Find longest subsequences ending at each consecutive array element. Initially assume the path to each element is the element itself.
        foreach ($this->sequence as $key => $val) {
            $this->paths[$key][] = $val;
            $this->ls($key);
        }
        // We have our max length, time to output the first array of that size. We could easily output all longest paths if needed, or sort them and return an array.
        foreach ($this->paths as $path) {
            if (count($path) === $this->max_length) {
                return $path;
            }
        }
        return false;
    }

    private function ls($i) {
        // Default to 1 for the first element regardless of its value.
        $this->subsequence_length[$i] = 1;
        // If this is not the first element, try and find a longer subsequence.
        if ($i !== 0) {
            $results = [];
            // Loop over elements left of ours.
            for ($j = 0; $j < $i; $j++) {
                // Having found an element vith a valid subsequence...
                if($this->sequence[$i] > $this->sequence[$j] && $this->subsequence_length[$i] < $this->subsequence_length[$j] + 1)
                {
                    // ...calculate the LS to the current element using the previous one, and save the longest path to $i-th element
                    $results[] = $this->ls($j);
                    $path = array_merge($this->paths[$j], [$this->sequence[$i]]);
                    if (count($path) > count($this->paths[$i])) $this->paths[$i] = $path;
                    // Update max length too.
                    if (count($path) > $this->max_length) $this->max_length = count($path);
                }
            }
            // Save subsequence length to $i-th element (including that element).
            $this->subsequence_length[$i] = !empty($results) ? max($results) + 1 : 1;
        }
        return $this->subsequence_length[$i];
    }
}

// $line = '1';
// $line = '7 3 5 8 -1 0 6 7';
// $line = '1 2 5 3 5 2 4 1';
// $line = '0 10 20 30 30 40 1 50 2 3 4 5 6';
// $line = '11 12 13 3 14 4 15 5 6 7 8 7 16 9 8';
// $line = '3 14 5 12 15 7 8 9 11 10 1';

$line = trim(fgets(STDIN));
$nums = explode(' ', $line);

$sequence = new Lis;

$result = $sequence->run($nums);

echo implode(' ', $result);