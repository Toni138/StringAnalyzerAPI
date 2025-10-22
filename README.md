String Analyzer API

A RESTful API that analyzes strings and stores their computed properties.

Features
- Computes:
  - length: total characters
  - is_palindrome: whether the string reads the same forward/backward
  - unique_characters: count of distinct characters
  - word_count: number of words
  - sha256_hash: unique identifier for the string
  - character_frequency_map: frequency of each character
- Supports CRUD and filtering

  Endpoints

 POST `/api/strings`
Analyze a string.
Request:
json
{
  "value": "madam"
}
