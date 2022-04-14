#!/bin/bash

# smells to run
SMELLS=(
	#'dead-local-store' 'duplicate-code' 'feature-envy' 'god-class' 'long-method' 'parameter-by-value' 'repeated-conditionals' 'self-assignment' 'short-circuit'
       	'type-checking-type-field' 'type-checking-rtti' 'dead-code' 'redundant-data-storage' 'in-line')
# variants to run for each smell
VARIANTS=('good' 'bad')
# number of times to run each variant of each smell
N=1

# time (in seconds) to sleep between each benchmark - that is, between each variant
SLEEP=1

# absolute path of the supplied binary in the repo
SMELL_BINARY_PATH=`realpath "binary/Smells"`

# folder name of the current run - current time in seconds
NOW=`date +%s`
mkdir "$NOW"
cd "$NOW"

# run each smell
for smell in "${SMELLS[@]}"
do
    # make a dir for the current smell and move into it
    mkdir "${smell}"
    cd "${smell}"

    # run each variant
    for variant in "${VARIANTS[@]}"
    do
        # make a dir for the current variant and move into it
        mkdir "${variant}"
        cd "${variant}"

        # make a quick and dirty script for running the smell
        touch "run.sh"
        echo "#!/bin/bash" >> "run.sh"
        echo "${SMELL_BINARY_PATH} ${smell} ${variant}" >> "run.sh"
        chmod +x "run.sh"

        RUN_PATH=`realpath "run.sh"`
        echo "Running code smell ${smell}, variant ${variant}"

        # run the benchmark
        # TODO: add -i with idle data immediately after "raplrs"
        sudo raplrs -n "${smell}-${variant}" benchmark "$RUN_PATH" -n "${N}"

        # leave dir
        cd ..

        # sleep
        sleep "${SLEEP}"
    done

    # leave dir
    cd ..
done
