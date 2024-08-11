## Status
![example workflow](https://github.com/cyberbartels/random-pet/actions/workflows/generate-name.yml/badge.svg)


# random-pet
A simple random pet generator library. Please refer to the [example flow](./.github/workflows/generate-name.yml).
## Usage
```yml
 - name: .NET Random Pet Name
   id: generate-name
   uses: cyberbartels/random-pet@main
```
Generated name is set in step's output "petname".
```yml
- name: Check result
  shell: bash
  run: |
    echo ${{ steps.generate-name.outputs.petname }}
``` 
