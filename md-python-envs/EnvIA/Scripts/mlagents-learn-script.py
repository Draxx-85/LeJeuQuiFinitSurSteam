#!f:\lejeuquifinitsursteam\md-python-envs\envia\scripts\python.exe
# EASY-INSTALL-ENTRY-SCRIPT: 'mlagents','console_scripts','mlagents-learn'
__requires__ = 'mlagents'
import re
import sys
from pkg_resources import load_entry_point

if __name__ == '__main__':
    sys.argv[0] = re.sub(r'(-script\.pyw?|\.exe)?$', '', sys.argv[0])
    sys.exit(
        load_entry_point('mlagents', 'console_scripts', 'mlagents-learn')()
    )
